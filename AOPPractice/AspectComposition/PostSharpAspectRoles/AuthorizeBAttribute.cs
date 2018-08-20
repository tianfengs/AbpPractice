using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
namespace PostSharpAspectRoles
{
    [Serializable]
    [ProvideAspectRole(StandardRoles.Security)]
    [AspectRoleDependency(
        AspectDependencyAction.Require,//这里必须有另一个角色切面存在
        StandardRoles.Caching)]//另一个角色切面是Caching
    public class AuthorizeBAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"This is in the {nameof(AuthorizeBAttribute)} class.");
        }
    }
}
