
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.JobEcowasCompetences.Dto;
using EcoRecruit.Recruitment.JobEcowasCompetences.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobEcowasCompetences
{
    public interface IJobEcowasCompetenceAppService : IApplicationService
    {
        Task<JobEcowasCompetenceDto> CreateAsync(CreateJobEcowasCompetenceDto JobEcowasCompetence);

        Task<JobEcowasCompetenceDto> UpdateAsync(JobEcowasCompetenceDto JobEcowasCompetence);

        Task  DeleteAsync(long id);

        Task<JobEcowasCompetenceDto> GetJobEcowasCompetenceAsync(long id);

        Task<PagedResultDto<JobEcowasCompetenceDto>> GetJobEcowasCompetencesAsync(PagedJobEcowasCompetenceResultRequestDto input);

      
    }
}
