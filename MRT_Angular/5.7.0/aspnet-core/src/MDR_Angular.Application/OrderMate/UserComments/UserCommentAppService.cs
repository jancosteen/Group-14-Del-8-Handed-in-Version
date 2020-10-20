using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.UserComments
{
    //[AbpAuthorize(PermissionNames.Pages_UC)]
    public class UserCommentAppService : AsyncCrudAppService<
        UserComment, UserCommentDto, int, PagedAndSortedResultRequestDto, UserCommentDto>, IUserCommentAppService
    {
        public UserCommentAppService(IRepository<UserComment> repository) : base(repository) { }

        public ListResultDto<UserCommentDto> GetUserCommentByRestId(int id)
        {
            var uc = Repository
                .GetAll().Where(x => x.RestaurantIdFk == id)
                .Include(i => i.StarRatingIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation)


                .ToList();
            return new ListResultDto<UserCommentDto>(ObjectMapper.Map<List<UserCommentDto>>(uc));
        }

        protected override IQueryable<UserComment> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                //.Include(i => i.ReservationRestaurant).ThenInclude(x => x.RestaurantIdFkNavigation)
                .Include(i => i.StarRatingIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation);
        }

        
    }
}
