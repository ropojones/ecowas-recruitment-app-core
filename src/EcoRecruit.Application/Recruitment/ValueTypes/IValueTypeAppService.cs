
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.ValueTypes.Dto;
using EcoRecruit.Recruitment.ValueTypes.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes
{
    public interface IValueTypeAppService : IApplicationService
    {
        Task<ValueTypeDto> CreateAsync(CreateValueTypeDto ValueType);

        Task<ValueTypeDto> UpdateAsync(ValueTypeDto ValueType);

        Task  DeleteAsync(int id);

        Task<ValueTypeDto> GetValueTypeAsync(int id);

        Task<PagedResultDto<ValueTypeDto>> GetValueTypesAsync(PagedValueTypeResultRequestDto input);

      
    }
}
