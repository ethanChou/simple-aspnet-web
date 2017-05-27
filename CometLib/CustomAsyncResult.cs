using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;

//就是继承了这个IAsyncResult接口,所以就可以是回调的参数类

namespace CometLib
{

    public class CustomAsyncResult : IAsyncResult
    {

        //这个接口的实现

        private object asyncState;

        private System.Threading.WaitHandle asyncWaitHandle;

        private bool completedSynchronously;

        private bool isCompleted;

        //一些个参数

        HttpContext context;

        AsyncCallback callBack;

        private string sessionId;

        string message;

        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public AsyncCallback CallBack
        {
            get { return callBack; }
            set { callBack = value; }
        }

        public HttpContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public bool CompletedSynchronously
        {
            get { return completedSynchronously; }
            set { completedSynchronously = value; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { return asyncWaitHandle; }
            set { asyncWaitHandle = value; }
        }

        public object AsyncState
        {
            get { return asyncState; }
            set { asyncState = value; }
        }

        //构造函数

        public CustomAsyncResult(HttpContext context, AsyncCallback cb, string sessionId)
        {

            this.SessionId = sessionId;

            this.Context = context;

            this.CallBack = cb;

        }

        //这个方法对于的是MyHandler调用哪个方法,

        //它的主要作用是,用某种浏览器检测工具,也就是能检测所有请求的工具,就能看出,它是结束当前的请求,在用js马上开始另一个请求,好处就是,感觉这个客服端是长连接的

        public void SetCompleted(bool iscompleted)
        {

            this.IsCompleted = iscompleted;

            if (iscompleted && this.CallBack != null)
            {

                CallBack(this);

            }

        }

    }
}