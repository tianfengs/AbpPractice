using System;

namespace DynamicProxyComposeAspects
{
    public interface IMyClass
    {
        void MyMethod();
    }
    public class MyClass : IMyClass
    {
        public void MyMethod()
        {
            Console.WriteLine($"This is in the {nameof(MyMethod)}");
        }
    }
}
