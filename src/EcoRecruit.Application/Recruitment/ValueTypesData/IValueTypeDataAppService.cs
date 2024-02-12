
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.ValueTypesData.Dto;
using EcoRecruit.Recruitment.ValueTypesData.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypesData
{
    public interface IValueTypeDataAppService : IApplicationService
    {
        Task<ValueTypeDataDto> CreateAsync(CreateValueTypeDataDto ValueTypeData);

        Task<ValueTypeDataDto> UpdateAsync(ValueTypeDataDto ValueTypeData);

        Task  DeleteAsync(int id);

        Task<ValueTypeDataDto> GetValueTypeDataAsync(int id);

        Task<PagedResultDto<ValueTypeDataDto>> GetValueTypeDatasAsync(PagedValueTypeDataResultRequestDto input);

      
    }
}
