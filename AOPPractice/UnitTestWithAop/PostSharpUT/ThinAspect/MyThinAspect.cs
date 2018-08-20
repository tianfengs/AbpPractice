using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharpUT.Complex;
using StructureMap;

namespace PostSharpUT.ThinAspect
{
    [Serializable]
    public class MyThinAspect:OnMethodBoundaryAspect
    {
        private IMyCrossCuttingConcern _concern;//该切面只有一个StructureMap提供的IMyCrossCuttingConcern依赖
        public override void RuntimeInitialize(MethodBase method)
        {
            if(!AspectSettings.On) return;
            _concern = ObjectFactory.GetInstance<IMyCrossCuttingConcern>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!AspectSettings.On) return;
            _concern.BeforeMethod("before");//委托给BeforeMethod方法
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (!AspectSettings.On) return;
            _concern.AfterMethod("after");//委托给AfterMethod方法
        }
    }
}
