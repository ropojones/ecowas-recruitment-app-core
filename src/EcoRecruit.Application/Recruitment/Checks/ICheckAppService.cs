
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Recruitment.Checks.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks
{
    public interface ICheckAppService : IApplicationService
    {
        Task<CheckDto> CreateAsync(CreateCheckDto Check);

        Task<CheckDto> UpdateAsync(CheckDto Check);

        Task  DeleteAsync(int id);

        Task<CheckDto> GetCheckAsync(int id);
        Task<PagedResultDto<CheckDto>> GetChecksAsync(PagedCheckResultRequestDto input);

      
    }
}
