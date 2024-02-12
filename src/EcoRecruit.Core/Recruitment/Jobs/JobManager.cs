using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public class JobManager: DomainService, IJobManager
    {
        private readonly IRepository<Job, int> _repository;
        public JobManager(IRepository<Job, int> repository)
        {
            _repository = repository;
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public IQueryable<Job> GetAll()
        {
            return  _repository.GetAll();
        }

        public async Task<Job> CreateAsync(Job value)
        {
            return await _repository.InsertAsync(value);
        }

        public async Task<Job> UpdateAsync(Job value)
        {
            return await _repository.UpdateAsync(value);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


    }
}