using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPMVCTest.MultiTenancy.Dto;

namespace ABPMVCTest.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
