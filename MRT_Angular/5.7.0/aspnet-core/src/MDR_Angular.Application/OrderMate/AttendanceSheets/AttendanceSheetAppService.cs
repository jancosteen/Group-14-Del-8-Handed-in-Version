using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.AttendanceSheets
{
    //[AbpAuthorize(PermissionNames.Pages_AS)]
    public class AttendanceSheetAppService : AsyncCrudAppService<
        AttendanceSheet, AttendanceSheetDto, int, PagedAndSortedResultRequestDto, AttendanceSheetDto>, IAttendanceSheetAppService
    {
        public AttendanceSheetAppService(IRepository<AttendanceSheet> repository) : base(repository) { }
    }
}
