当一个http请求被送入到HttpRuntime之后，这个Http请求会继续被送入到一个被称之为HttpApplication Factory的一个容器当中，，而这个容器会给出一个HttpApplication实例来处理传递进来的http请求，而后这个Http请求会依次进入到如下几个容器中：
HttpModule --> HttpHandler Factory --> HttpHandler
当系统内部的HttpHandler的ProcessRequest方法处理完毕之后，整个Http Request就被处理完成了，客户端也就得到相应的东东了。
完整的http请求在asp.net framework中的处理流程：
HttpRequest-->inetinfo.exe->ASPNET_ISAPI.DLL-->Http Pipeline-->ASPNET_WP.EXE-->HttpRuntime-->HttpApplication Factory-->HttpApplication-->HttpModule-->HttpHandler Factory-->HttpHandler-->HttpHandler.ProcessRequest()
如果想在中途截获一个httpRequest并做些自己的处理，就应该在HttpRuntime运行时内部来做到这一点，确切的说时在HttpModule这个容器中做到这个的。