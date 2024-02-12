
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Projects.Dto;
using EcoRecruit.Recruitment.Projects.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectDto> CreateAsync(CreateProjectDto Project);

        Task<ProjectDto> UpdateAsync(ProjectDto Project);

        Task  DeleteAsync(long id);

        Task<ProjectDto> GetProjectAsync(long id);

        Task<PagedResultDto<ProjectDto>> GetProjectsAsync(PagedProjectResultRequestDto input);

      
    }
}
