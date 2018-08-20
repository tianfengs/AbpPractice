using Abp.Web.Mvc.Views;

namespace ABPMVCTest.Web.Views
{
    public abstract class ABPMVCTestWebViewPageBase : ABPMVCTestWebViewPageBase<dynamic>
    {

    }

    public abstract class ABPMVCTestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ABPMVCTestWebViewPageBase()
        {
            LocalizationSourceName = ABPMVCTestConsts.LocalizationSourceName;
        }
    }
}