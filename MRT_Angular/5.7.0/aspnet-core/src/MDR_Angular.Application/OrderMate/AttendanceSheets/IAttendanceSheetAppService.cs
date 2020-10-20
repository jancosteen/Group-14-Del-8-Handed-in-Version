using Abp.Application.Services;

namespace MDR_Angular.OrderMate.AttendanceSheets
{
    public interface IAttendanceSheetAppService : IAsyncCrudAppService<AttendanceSheetDto>
    {
    }
}
