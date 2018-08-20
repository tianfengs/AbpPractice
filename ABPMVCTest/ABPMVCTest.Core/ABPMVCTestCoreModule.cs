using System.Reflection;
using System.Web;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources.Resource;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using ABPMVCTest.Authorization;
using ABPMVCTest.Authorization.Roles;
using ABPMVCTest.Localization.ResSource;

namespace ABPMVCTest
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ABPMVCTestCoreModule : AbpModule
    {

        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            //Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    ABPMVCTestConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "ABPMVCTest.Localization.XmlSource"
                        )
                    )
                );

            //Configuration.Localization.Sources.Add(new DictionaryBasedLocalizationSource(
            //    ABPMVCTestConsts.LocalizationSourceName,
            //    new XmlFileLocalizationDictionaryProvider(
            //        HttpContext.Current.Server.MapPath("~/Localization/XmlSource")
            //         )
            //    )
            // );

            //Configuration.Localization.Sources.Add(
            //        new ResourceFileLocalizationSource(
            //             ABPMVCTestConsts.LocalizationSourceName,
            //            AbpMvcTest.ResourceManager)
            //);

            //Configuration.Localization.Sources.Add(new DictionaryBasedLocalizationSource(
            //    ABPMVCTestConsts.LocalizationSourceName,
            //    new JsonFileLocalizationDictionaryProvider(
            //        HttpContext.Current.Server.MapPath("~/Localization/JsonSource")
            //         )
            //    )
            // );

            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //        ABPMVCTestConsts.LocalizationSourceName,
            //        new JsonEmbeddedFileLocalizationDictionaryProvider(
            //            Assembly.GetExecutingAssembly(),
            //            "ABPMVCTest.Localization.JsonSource"
            //            )
            //        )
            //    );
            //Configuration.Localization.Sources.Add(
            //    new DictionaryBasedLocalizationSource(
            //                ABPMVCTestConsts.LocalizationSourceName,
            //                new JsonFileLocalizationDictionaryProvider(
            //                    HttpContext.Current.Server.MapPath("~/Localization/JsonSource")))
            //    );
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<ABPMVCTestAuthorizationProvider>();
        }

        public override void Initialize()
        {

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
