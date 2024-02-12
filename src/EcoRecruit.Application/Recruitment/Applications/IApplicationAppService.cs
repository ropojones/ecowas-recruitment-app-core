using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Recruitment.Applications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applications
{
    public interface IApplicationAppService : IApplicationService
    {
        Task<ApplicationDto> CreateAsync(CreateApplicationDto applicant);

        Task<ApplicationDto> UpdateAsync(ApplicationDto applicant);

        Task  DeleteAsync(long id);

        Task<ApplicationDto> GetApplicationAsync(long id);

        Task<PagedResultDto<ApplicationDto>> GetApplicationsAsync(PagedApplicationResultRequestDto input);
       
    }
}
