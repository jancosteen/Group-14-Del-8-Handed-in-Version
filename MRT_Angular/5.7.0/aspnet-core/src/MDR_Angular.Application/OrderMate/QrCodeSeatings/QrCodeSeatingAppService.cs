using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.QrCodeSeatings
{
    //[AbpAuthorize(PermissionNames.Pages_QCS)]
    public class QrCodeSeatingAppService : AsyncCrudAppService<
        QrCodeSeating, QrCodeSeatingDto, int, PagedAndSortedResultRequestDto, QrCodeSeatingDto>, IQrCodeSeatingAppService
    {
        public QrCodeSeatingAppService(IRepository<QrCodeSeating> repository) : base(repository) { }
    }
}
