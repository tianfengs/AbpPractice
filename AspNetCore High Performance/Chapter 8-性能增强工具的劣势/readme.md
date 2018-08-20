1. 用于Error Log的优秀的ASP.NET包 Error Logging Modules and Handlers (ELMAH) 可以捕获未处理的异常。文档地址：http://elmah.github.io/
2. 对于ASP .Net Core,有个类似的包Microsoft.AspNetCore.Diagnostics.Elm (Error Log Middlerware)
3.Feature Switch:功能切换，举个简单例子，在Home控制器的Index方法中，通过随机数来控制视图的显示。<25显示新页面，25<x<100显示旧页面。