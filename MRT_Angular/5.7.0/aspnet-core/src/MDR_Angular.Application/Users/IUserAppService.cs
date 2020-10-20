using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.Roles.Dto;
using MDR_Angular.Users.Dto;
using System.Threading.Tasks;

namespace MDR_Angular.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
