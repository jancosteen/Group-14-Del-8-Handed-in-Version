using Abp.Authorization;
using Abp.Runtime.Session;
using MDR_Angular.Configuration.Dto;
using System.Threading.Tasks;

namespace MDR_Angular.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MDR_AngularAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
