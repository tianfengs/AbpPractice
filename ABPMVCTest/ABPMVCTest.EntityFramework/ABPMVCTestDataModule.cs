using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using ABPMVCTest.EntityFramework;

namespace ABPMVCTest
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(ABPMVCTestCoreModule))]
    public class ABPMVCTestDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
