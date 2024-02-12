using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.ValueTypes.Dto;
using EcoRecruit.Recruitment.ValueTypes;
using EcoRecruit.Recruitment.ValueTypes.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes
{
    public class ValueTypeAppService : ApplicationService, IValueTypeAppService
    {
        private readonly IRepository<ValueType, int> _valueTypeRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ValueTypeManager _valueTypeManager;

        public ValueTypeAppService(IRepository<ValueType, int> valueTypeRepository, IMapper mapper, ILocalizationManager localization, ValueTypeManager valueTypeManager)
        {
          _valueTypeRepository = valueTypeRepository;
            _mapper = mapper;
            _localization = localization;
            _valueTypeManager = valueTypeManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<ValueTypeDto> GetValueTypeAsync(int id)
        {
            var valueType = await _valueTypeRepository.GetAsync(id);
            return _mapper.Map<ValueType, ValueTypeDto>(valueType);

        }
   

        public async Task<PagedResultDto<ValueTypeDto>> GetValueTypesAsync(PagedValueTypeResultRequestDto input)
        {

            var listOfValueTypes =  _valueTypeManager.GetAll();
            var query = listOfValueTypes;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Name")
                        {
                            query = query.Where(app => app.Name.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                       
                    }
                }

               
              
            }
            //// Apply sorting criteria
            if (!string.IsNullOrEmpty(input.Sorting))
            {
                var sortParam = input.Sorting.Split(':');
                switch (sortParam[0])
                {
                    case "Name":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                        break;
                   
                    default:
                        break;
                }
            }
            var ValueTypes = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ValueTypeDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ValueTypeDto>>(ValueTypes)
            };

        }

        public async  Task<ValueTypeDto> CreateAsync(CreateValueTypeDto input)
        {
    
            var valueType = await _valueTypeRepository.FirstOrDefaultAsync(app => app.Name == input.Name);

            if(valueType != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingValueType"));
            }
            
            valueType = _mapper.Map<ValueType>(input);
            await _valueTypeManager.CreateAsync(valueType);
            return _mapper.Map<ValueType, ValueTypeDto>(valueType);
           
        }

        public async Task<ValueTypeDto> UpdateAsync(ValueTypeDto input)
        {
            var valueType = await _valueTypeRepository.GetAsync(input.Id);
            if (valueType == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingValueType"));
            }

            valueType = _mapper.Map<ValueType>(input);
            await _valueTypeManager.UpdateAsync(valueType);
            return _mapper.Map<ValueType, ValueTypeDto>(valueType);

        }

        public async Task DeleteAsync(int id)
        {
            await _valueTypeManager.DeleteAsync(id);
        }

    


    }
}
