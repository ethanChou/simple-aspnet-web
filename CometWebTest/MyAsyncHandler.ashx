<%@ WebHandler Language="C#" Class="MyAsyncHandler" %>

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.SessionState;
using CometLib;

public class MyAsyncHandler : IHttpAsyncHandler, IRequiresSessionState, IReadOnlySessionState
{
    public MyAsyncHandler()
    {
        Log.Write("MyAsyncHandler" + this.GetHashCode());
    }

    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {

        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

        string sessionId = context.Request.QueryString["sessionId"];
    
        //查找Queue这个集合  SessionId ==传过来的sessionId  !=null
        if (Container.Queue.Find(q => q.SessionId == sessionId) != null)
        {
            int index = Container.Queue.IndexOf(Container.Queue.Find(q => q.SessionId == sessionId));
            Container.Queue[index].Context = context;
            Container.Queue[index].CallBack = cb;
            return Container.Queue[index];
        }
        //MyAsyncResult 这个类是 回调的参数类(相当于 你定义一个事件 使用的泛型的   public event EventHandler<MyEvargs> Events;  MyEvargs这个类继承了EventArgs  同样的道理)

        CustomAsyncResult asyncResult = new CustomAsyncResult(context, cb, sessionId);

        Container.Queue.Add(asyncResult);

        return asyncResult;

    }

    //这个方法是这个异步接口的另一个方法

    public void EndProcessRequest(IAsyncResult result)
    {

        CustomAsyncResult rslt = (CustomAsyncResult)result;

        //向别的客服端推送  某个 客服端发送的 信息 

        rslt.Context.Response.Write(rslt.Message);

        rslt.Message = string.Empty;

    }

    //为什么不实现这个方法  (因为IhttpAsyncHandler接口继承了IHttpHandler这个接口,所以实现接口的时候,就实现了它,但是 我们不管它)

    #region IHttpHandler 成员 不实现

    public bool IsReusable
    {

        get { return true; }

    }

    public void ProcessRequest(HttpContext context)
    {

    }

    #endregion

}