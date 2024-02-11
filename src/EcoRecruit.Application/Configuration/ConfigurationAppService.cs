using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EcoRecruit.Configuration.Dto;

namespace EcoRecruit.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EcoRecruitAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
