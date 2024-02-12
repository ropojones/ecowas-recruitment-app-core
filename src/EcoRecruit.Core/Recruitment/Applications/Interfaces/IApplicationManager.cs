using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applications.Interfaces
{
    public interface IApplicationManager: IDomainService
    {
        Task<Application> GetByIdAsync(long id);
       IQueryable<Application> GetAll();
        Task<Application> CreateAsync(Application value);
        Task<Application> UpdateAsync(Application value);
        Task DeleteAsync(long id);
    }
}