using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes.Interfaces
{
    public interface IValueTypeDataManager:IDomainService
    {

        Task<ValueTypeData> GetByIdAsync(int id);
        IQueryable<ValueTypeData> GetAll();
        Task<ValueTypeData> CreateAsync(ValueTypeData value);
        Task<ValueTypeData> UpdateAsync(ValueTypeData value);
        Task DeleteAsync(int id);

    }
}