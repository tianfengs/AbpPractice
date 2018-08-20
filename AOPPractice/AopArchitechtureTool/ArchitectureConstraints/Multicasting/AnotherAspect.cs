using PostSharp.Aspects;
using System;
using static System.Console;
namespace ArchitectureConstraints.Multicasting
{
    [Serializable]
    class AnotherAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            WriteLine($"Another aspect was applied to {args.Method}");
        }
    }
}
