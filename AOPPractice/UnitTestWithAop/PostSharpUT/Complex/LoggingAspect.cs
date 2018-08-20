using System;
using System.Reflection;
using PostSharp.Aspects;
using StructureMap;

namespace PostSharpUT.Complex
{
#define UnitTesting
    [Serializable]
    public class LoggingAspect:OnMethodBoundaryAspect
    {
       #if !UnitTesting
		[NonSerialized]
        private  ILoggingService _loggingService;

        public override void RuntimeInitialize(MethodBase method)
        {
            _loggingService = ObjectFactory.GetInstance<ILoggingService>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _loggingService.Write("Log start");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _loggingService.Write("Log end");
        }  
	#endif
    }
}