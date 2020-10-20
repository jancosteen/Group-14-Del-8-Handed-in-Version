using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.Advertisements.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Advertisements
{
    //[AbpAuthorize(PermissionNames.Pages_A)]
    public class AdvertisementAppService : AsyncCrudAppService<
        Advertisement, AdvertisementDto, int, PagedAndSortedResultRequestDto, AdvertisementDto>, IAdvertisementAppService
    {
        public AdvertisementAppService(IRepository<Advertisement> repository) : base(repository) { }

        protected override IQueryable<Advertisement> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.AdvertisementDateIdFkNavigation)
                .Include(i => i.AdvertisementPriceIdFkNavigation);
                
        }

        public List<Advertisement> GetAdvById(int adId)
        {
            var advs = Repository.GetAll().Where(x => x.Id.Equals(adId))
                .Include(i => i.AdvertisementDateIdFkNavigation)
                .Include(i => i.AdvertisementPriceIdFkNavigation)
                .ToList();
                
            return advs;
        }
    }
}
