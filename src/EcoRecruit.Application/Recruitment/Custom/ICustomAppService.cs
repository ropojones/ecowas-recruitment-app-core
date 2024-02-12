
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Customs.Dto;
using EcoRecruit.Recruitment.Customs.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Customs
{
    public interface ICustomAppService : IApplicationService
    {
        Task<CustomDto> CreateAsync(CreateCustomDto Custom);

        Task<CustomDto> UpdateAsync(CustomDto Custom);

        Task  DeleteAsync(long id);

        Task<CustomDto> GetCustomAsync(long id);

        Task<PagedResultDto<CustomDto>> GetCustomsAsync(PagedCustomResultRequestDto input);

      
    }
}
