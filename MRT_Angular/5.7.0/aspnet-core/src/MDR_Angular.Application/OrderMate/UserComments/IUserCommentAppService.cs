using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MDR_Angular.OrderMate.UserComments
{
    public interface IUserCommentAppService : IAsyncCrudAppService<UserCommentDto>
    {
        ListResultDto<UserCommentDto> GetUserCommentByRestId(int id);

    }
}
