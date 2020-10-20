using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuRestaurants.Dto;

namespace MDR_Angular.OrderMate.MenuRestaurants
{
    //[AbpAuthorize(PermissionNames.Pages_MR)]
    public class MenuRestaurantAppService : AsyncCrudAppService<
        MenuRestaurant, MenuRestaurantDto, int, PagedAndSortedResultRequestDto, MenuRestaurantDto>, IMenuRestaurantAppService
    {
        public MenuRestaurantAppService(IRepository<MenuRestaurant> repository) : base(repository) { }
    }
}
