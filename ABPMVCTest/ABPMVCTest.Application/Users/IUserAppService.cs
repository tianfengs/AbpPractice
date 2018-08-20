using System.Threading.Tasks;
using Abp.Application.Services;
using ABPMVCTest.Users.Dto;

namespace ABPMVCTest.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}