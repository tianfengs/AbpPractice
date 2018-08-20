using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharpUT.Complex;

namespace PostSharpUT.ThinAspect
{
    public class MyCrossCuttingConcern:IMyCrossCuttingConcern
    {
        private ILoggingService _loggingService;

        public MyCrossCuttingConcern(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        public void BeforeMethod(string logMsg)
        {
            _loggingService.Write(logMsg);
        }

        public void AfterMethod(string logMsg)
        {
            _loggingService.Write(logMsg);
        }
    }
}
