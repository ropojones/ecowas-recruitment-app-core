
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Trainings.Dto;
using EcoRecruit.Recruitment.Trainings.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Trainings
{
    public interface ITrainingAppService : IApplicationService
    {
        Task<TrainingDto> CreateAsync(CreateTrainingDto Training);

        Task<TrainingDto> UpdateAsync(TrainingDto Training);

        Task  DeleteAsync(long id);

        Task<TrainingDto> GetTrainingAsync(long id);

        Task<PagedResultDto<TrainingDto>> GetTrainingsAsync(PagedTrainingResultRequestDto input);

      
    }
}
