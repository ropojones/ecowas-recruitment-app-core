using System.Threading.Tasks;
using EcoRecruit.Configuration.Dto;

namespace EcoRecruit.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
