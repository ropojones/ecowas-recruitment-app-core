using System.Threading.Tasks;
using Abp.Application.Services;
using EcoRecruit.Sessions.Dto;

namespace EcoRecruit.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
