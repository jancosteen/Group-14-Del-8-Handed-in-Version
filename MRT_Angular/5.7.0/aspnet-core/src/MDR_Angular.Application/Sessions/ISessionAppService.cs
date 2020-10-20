using Abp.Application.Services;
using MDR_Angular.Sessions.Dto;
using System.Threading.Tasks;

namespace MDR_Angular.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
