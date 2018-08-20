using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace ABPMVCTest
{
    [DependsOn(typeof(ABPMVCTestCoreModule), typeof(AbpAutoMapperModule))]
    public class ABPMVCTestApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
