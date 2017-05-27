using CometLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;

namespace CometLib
{

    /// <summary>
    /// MyHttpModule 的摘要说明
    /// </summary>
    public class CustomHttpModule : IHttpModule, IRequiresSessionState
    {
        public CustomHttpModule()
        {
            Log.Write("MyHttpModule:" + this.GetHashCode());
        }

        public void Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication App)
        {
            // App.AcquireRequestState += new EventHandler(AcquireRequestState);
            App.BeginRequest += new EventHandler(BeginRequest);
            //App.AuthenticateRequest += new EventHandler(AuthenticateRequest);
            //App.AuthorizeRequest += new EventHandler(AuthorizeRequest);
            //App.Disposed += new EventHandler(Disposed);
            App.EndRequest += new EventHandler(EndRequest);
            App.Error += new EventHandler(Error);
            //App.MapRequestHandler += new EventHandler(MapRequestHandler);
            //App.PostAcquireRequestState += new EventHandler(PostAcquireRequestState);
            //App.PostAuthenticateRequest += new EventHandler(PostAuthenticateRequest);
            //App.PostAuthorizeRequest += new EventHandler(PostAuthorizeRequest);
            ////App.PostLogRequest += new EventHandler(PostLogRequest);
            //App.PostMapRequestHandler += new EventHandler(PostMapRequestHandler);
            //App.PostReleaseRequestState += new EventHandler(PostReleaseRequestState);
            //App.PostRequestHandlerExecute += new EventHandler(PostRequestHandlerExecute);
            //App.PostResolveRequestCache += new EventHandler(PostResolveRequestCache);
            //App.PostUpdateRequestCache += new EventHandler(PostUpdateRequestCache);
            //App.PreRequestHandlerExecute += new EventHandler(PreRequestHandlerExecute);
            //App.PreSendRequestHeaders += new EventHandler(PreSendRequestHeaders);
            //App.PreSendRequestContent += new EventHandler(PreSendRequestContent);
            //App.ReleaseRequestState += new EventHandler(ReleaseRequestState);
            //App.ResolveRequestCache += new EventHandler(ResolveRequestCache);
            //App.UpdateRequestCache += new EventHandler(UpdateRequestCache);
        }

        private void BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            Log.Write("" + time + "  + IHttpModule：BeginRequest（执行Http请求管线链中第一个事件时发生）" + request.Path);
            //response.Write("" + time + "  + IHttpModule：BeginRequest（执行Http请求管线链中第一个事件时发生）");
        }

        private void AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：AcquireRequestState(与当前建立会话时发生)");
            Log.Write("" + time + "  + IHttpModule：AcquireRequestState(与当前建立会话时发生)");
            if (context.Session != null && context.Session["T"] != null)
            {
                response.Write(" + " + context.Session["T"].ToString());
            }
            else
            {
                response.Write(" Session未收到!");
            }
        }

        private void AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：AuthenticateRequest(安全模块建立用户标记时发生)");
            Log.Write("" + time + "  + IHttpModule：AuthenticateRequest(安全模块建立用户标记时发生)");
        }

        private void AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：AuthorizeRequest(安全模块验证用户授权时发生)");
            Log.Write("" + time + "  + IHttpModule：AuthorizeRequest(安全模块验证用户授权时发生)");
        }

        private void Disposed(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：Disposed(释放应用时发生)");
            Log.Write("" + time + "  + IHttpModule：Disposed(释放应用时发生)");

        }


        private void EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            // response.Write("" + time + "  + IHttpModule：EndRequest(执行Http请求管线链中最后一个事件时发生)");
            Log.Write("" + time + "  + IHttpModule：EndRequest(执行Http请求管线链中最后一个事件时发生)");

        }

        private void Error(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + Error(Error事件时发生)");
            Log.Write("" + time + "  + Error(Error事件时发生)");
        }

        private void PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostAcquireRequestState(已经获得当前请求状态时发生)");
            Log.Write("" + time + "  + IHttpModule：PostAcquireRequestState(已经获得当前请求状态时发生)");
            if (context.Session != null && context.Session["T"] != null)
            {
                response.Write(" + " + context.Session["T"].ToString());
            }
            else
            {
                response.Write(" Session未收到!");
            }
        }

        private void PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostAuthenticateRequest(已建立用户标识时发生)");
            Log.Write("" + time + "  + IHttpModule：PostAuthenticateRequest(已建立用户标识时发生)");
        }

        private void PostAuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostAuthorizeRequest(当前请求的用户已获得授权时发生)");
            Log.Write("" + time + "  + IHttpModule：PostAuthorizeRequest(当前请求的用户已获得授权时发生)");
        }

        private void PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostMapRequestHandler(当前请求事件映射到相应事件后发生)");
            Log.Write("" + time + "  + IHttpModule：PostMapRequestHandler(当前请求事件映射到相应事件后发生)");

        }

        private void PostReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + PostReleaseRequestState(完成请求事件并且请求状态已存储时发生)");
            Log.Write("" + time + "  + PostReleaseRequestState(完成请求事件并且请求状态已存储时发生)");
        }

        private void PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostRequestHandlerExecute(ASP.Net事件执行完毕时发生)");
            Log.Write("" + time + "  + IHttpModule：PostRequestHandlerExecute(ASP.Net事件执行完毕时发生)");
        }

        private void PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostResolveRequestCache(跳过当前请求并接受来自缓存数据时发生)");
            Log.Write("" + time + "  + IHttpModule：PostResolveRequestCache(跳过当前请求并接受来自缓存数据时发生)");
        }

        private void PostUpdateRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PostUpdateRequestCache(事件缓存被更新时发生)");
            Log.Write("" + time + "  + IHttpModule：PostUpdateRequestCache(事件缓存被更新时发生)");

        }

        private void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PreRequestHandlerExecute(页面事件执行前发生)");
            Log.Write("" + time + "  + IHttpModule：PreRequestHandlerExecute(页面事件执行前发生)");

            if (context.Session != null && context.Session["T"] != null)
            {
                response.Write(" + " + context.Session["T"].ToString());
            }
            else
            {
                response.Write(" Session未收到!");
            }
        }

        private void PreSendRequestContent(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PreSendRequestContent(向客户端发送内容之前发生)");
            Log.Write("" + time + "  + IHttpModule：PreSendRequestContent(向客户端发送内容之前发生)");

        }

        private void PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：PreSendRequestHeaders(向客户端发送HttP头之前发生)");
            Log.Write("" + time + "  + IHttpModule：PreSendRequestHeaders(向客户端发送HttP头之前发生)");
        }

        private void ReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：ReleaseRequestState(事件执行完成之后状态处理)");
            Log.Write("" + time + "  + IHttpModule：ReleaseRequestState(事件执行完成之后状态处理)");
        }

        private void ResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：ResolveRequestCache(从缓存中发生数据请求时)");
            Log.Write("" + time + "  + IHttpModule：ResolveRequestCache(从缓存中发生数据请求时)");
        }
        private void UpdateRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString("000");
            response.Write("" + time + "  + IHttpModule：UpdateRequestCache(时间执行完毕，为缓存新的事件准备)");
            Log.Write("" + time + "  + IHttpModule：UpdateRequestCache(时间执行完毕，为缓存新的事件准备)");
        }
    }
}
