using System;
using System.Reflection;
using PostSharp.Aspects;
using StructureMap;

namespace PostSharpUT.Complex
{
    public static class AspectSettings
    {
        public static bool On = true;
    }
    
    [Serializable]
    public class LoggingAspect2:OnMethodBoundaryAspect
    {
        [NonSerialized]
        private  ILoggingService _loggingService;

        public override void RuntimeInitialize(MethodBase method)
        {
            if(!AspectSettings.On) return;
            _loggingService = ObjectFactory.GetInstance<ILoggingService>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!AspectSettings.On) return;
            _loggingService.Write("Log start");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (!AspectSettings.On) return;
            _loggingService.Write("Log end");
        }

    }
}