using Abp.Domain.Repositories;
using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applications.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applications
{
    public class ApplicationManager: DomainService, IApplicationManager
    {
        private readonly IRepository<Application, long> _repository;
        public ApplicationManager(IRepository<Application, long> repository)
        {
            _repository = repository;
        }

        public async Task<Application> GetByIdAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public IQueryable<Application> GetAll()
        {
            return  _repository.GetAll();
        }

        public async Task<Application> CreateAsync(Application value)
        {
            return await _repository.InsertAsync(value);
        }

        public async Task<Application> UpdateAsync(Application value)
        {
            return await _repository.UpdateAsync(value);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
