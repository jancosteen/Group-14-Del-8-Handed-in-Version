using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MDR_Angular.OrderMate.Menus
{
    public interface IMenuAppService : IAsyncCrudAppService<MenuDto>
    {
        ListResultDto<MenuDto> GetMenuById(int id);
    }
}
