using System.Collections.Generic;
using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Zero.Configuration;

namespace EcoRecruit.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()),
                new SettingDefinition(EmailSettingNames.Smtp.Host, "mail.teamoption.ng"),
                new SettingDefinition(EmailSettingNames.Smtp.Port, "485"),
                new SettingDefinition(EmailSettingNames.Smtp.UserName, "ecowas@teamoption.ng"),
                new SettingDefinition(EmailSettingNames.Smtp.Password, "P@ssw0rd123"),
                new SettingDefinition(EmailSettingNames.Smtp.EnableSsl, "false"),
                new SettingDefinition(EmailSettingNames.Smtp.UseDefaultCredentials, "false"),
                new SettingDefinition(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin, "false", scopes: SettingScopes.Application, isVisibleToClients: false),
         };
        }
    }
}
