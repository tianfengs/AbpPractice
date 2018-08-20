using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
namespace PostSharpAspectRoles
{
    [Serializable]
    [ProvideAspectRole(StandardRoles.Security)]
    [AspectRoleDependency(
        AspectDependencyAction.Order,//不同种类的关系枚举，这里按顺序严格排序
        AspectDependencyPosition.Before,//该切面角色的位置位于另一个角色之前
        StandardRoles.Caching)]//另一个角色就是Caching
    public class AuthorizeAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"This is in the {nameof(AuthorizeAttribute)} class.");
        }
    }
}
