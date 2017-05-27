<%@ WebHandler Language="C#" Class="MyHandler" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using CometLib;


//继承并实现了 IHttpHandler   接口

public class MyHandler : IHttpHandler, IRequiresSessionState, IReadOnlySessionState 
{
    public MyHandler ()
    {
        Log.Write("MyHandler"+this.GetHashCode());
    }

    //这个属性,和方法 都是实现 IHttpHandler 的

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        //设置不让客服端缓存

        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

        List<CustomAsyncResult> userlist = Container.Queue;

        string sessionId = context.Request.QueryString["sessionId"];

        string message = context.Request.QueryString["message"];

        foreach (CustomAsyncResult res in userlist)
        {
            //如果不是自己就推
            if (res.SessionId != sessionId)
            {
                //激发callback，结束请求      
                res.Message = message;
                res.SetCompleted(true);
            }
        }
    }

}