using System;
using System.Collections.Generic;
using System.Web;

namespace CometLib
{

    /// <summary>
    /// Container 的摘要说明
    /// </summary>
    public class Container
    {
        public Container()
        {
        
        }

        //这个集合 用于存放 所有请求的

        public static List<CustomAsyncResult> Queue = new List<CustomAsyncResult>();
    }
}