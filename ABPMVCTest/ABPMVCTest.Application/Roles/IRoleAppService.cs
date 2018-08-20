using System.Threading.Tasks;
using Abp.Application.Services;
using ABPMVCTest.Roles.Dto;

namespace ABPMVCTest.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
