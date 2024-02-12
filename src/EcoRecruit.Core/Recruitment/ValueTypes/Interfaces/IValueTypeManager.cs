using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes.Interfaces
{
    public interface IValueTypeManager : IDomainService
    {

        Task<ValueType> GetByIdAsync(int id);
        IQueryable<ValueType> GetAll();
        Task<ValueType> CreateAsync(ValueType value);
        Task<ValueType> UpdateAsync(ValueType value);
        Task DeleteAsync(int id);
    }
}