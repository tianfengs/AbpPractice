using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;

namespace PostSharpAspectRoles
{
    [Serializable]
    //StandardRoles类里面定义许多静态变量
    [ProvideAspectRole(StandardRoles.Caching)]//ProvideAspectRole特性
    public class CachingAttribute:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"This is in the {nameof(CachingAttribute)} class.");
        }
    }
}
