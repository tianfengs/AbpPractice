using System;
namespace PostSharpAspectRoles
{
    [Caching]
    [Authorize]
    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
        }
    }

    [AuthorizeB]
    [Caching]//测试AspectDependencyAction.Require取消注释
    class MyClass
    {
    }
}
