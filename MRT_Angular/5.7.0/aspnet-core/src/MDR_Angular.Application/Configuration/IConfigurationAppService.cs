using MDR_Angular.Configuration.Dto;
using System.Threading.Tasks;

namespace MDR_Angular.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
