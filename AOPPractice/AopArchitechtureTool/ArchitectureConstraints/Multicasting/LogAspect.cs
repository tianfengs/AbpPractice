using PostSharp.Aspects;
using System;
using static System.Console;
namespace ArchitectureConstraints.Multicasting
{
    [Serializable]
    public class LogAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            WriteLine($"Aspect was applied to {args.Method.Name}");
        }
    }

    //演示AttributeExclude
    //[LogAspect]
    //class MyClass
    //{
    //    public void Method1() { }
    //    public void Method2() {
    //        Method3();
    //    }
    //    [LogAspect(AttributeExclude =true)]//从多播中排除这个方法
    //    private void Method3(){}
    //}

    //演示AspectPriority
    //[LogAspect(AspectPriority =2)]//LogAspect有最高的优先级
    //[AnotherAspect(AspectPriority =1)]
    //class MyClass
    //{
    //    public void Method1() { }
    //    public void Method2()
    //    {
    //        Method3();
    //    }
    //    private void Method3() { }
    //}

    /// <summary>
    /// 演示AttributeTargetElements
    /// </summary>
    [LogAspect(AttributeTargetElements =PostSharp.Extensibility.MulticastTargets.InstanceConstructor)]
    class MyClass
    {
        public MyClass() { }
        public MyClass(int n) { }
        public void Method1() { }
        public void Method2()
        {
            Method3();
        }
        private void Method3() { }
    }
}
