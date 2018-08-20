using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpUT.ThinAspect
{
    public interface IMyCrossCuttingConcern
    {
        void BeforeMethod(string logMsg);
        void AfterMethod(string logMsg);
    }
}
