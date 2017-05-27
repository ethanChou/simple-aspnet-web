using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CometLib
{
    public class CustomHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("我是经过HelloHttpHandler处理的！");
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
}
