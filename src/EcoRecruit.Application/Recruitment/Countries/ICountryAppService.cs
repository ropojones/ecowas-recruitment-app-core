
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Countries.Dto;
using EcoRecruit.Recruitment.Countries.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Countries
{
    public interface ICountryAppService : IApplicationService
    {
        Task<CountryDto> CreateAsync(CreateCountryDto Country);

        Task<CountryDto> UpdateAsync(CountryDto Country);

        Task  DeleteAsync(int id);

        Task<CountryDto> GetCountryAsync(int id);

        Task<PagedResultDto<CountryDto>> GetCountriesAsync(PagedCountryResultRequestDto input);

      
    }
}
