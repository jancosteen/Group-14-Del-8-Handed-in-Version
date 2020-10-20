using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.QrCodes
{
    //[AbpAuthorize(PermissionNames.Pages_QC)]
    public class QrCodeAppService : AsyncCrudAppService<
        QrCode, QrCodeDto, int, PagedAndSortedResultRequestDto, QrCodeDto>, IQrCodeAppService
    {
        public QrCodeAppService(IRepository<QrCode> repository) : base(repository) { }

        protected override IQueryable<QrCode> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                //.Include(i => i.ReservationRestaurant).ThenInclude(x => x.RestaurantIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation);
        }

        public ListResultDto<QrCodeDto> GetQrCodeByRestId(int id)
        {
            var reservation = Repository
                .GetAll().Where(x => x.RestaurantIdFk == id)
                .Include(i => i.RestaurantIdFkNavigation)


                .ToList();
            return new ListResultDto<QrCodeDto>(ObjectMapper.Map<List<QrCodeDto>>(reservation));
        }
    }
}
