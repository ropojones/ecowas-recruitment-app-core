using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.ValueTypesData.Dto;
using EcoRecruit.Recruitment.ValueTypes;
using EcoRecruit.Recruitment.ValueTypesData.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypesData
{
    public class ValueTypeDataAppService : ApplicationService, IValueTypeDataAppService
    {
        private readonly IRepository<ValueTypeData, int> _valueTypeDataRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ValueTypeDataManager _valueTypeDataManager;

        public ValueTypeDataAppService(IRepository<ValueTypeData, int> valueTypeDataRepository, IMapper mapper, ILocalizationManager localization, ValueTypeDataManager valueTypeDataManager)
        {
          _valueTypeDataRepository = valueTypeDataRepository;
            _mapper = mapper;
            _localization = localization;
            _valueTypeDataManager = valueTypeDataManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<ValueTypeDataDto> GetValueTypeDataAsync(int id)
        {
            var valueTypeData = await _valueTypeDataRepository.GetAsync(id);
            return _mapper.Map<ValueTypeData, ValueTypeDataDto>(valueTypeData);

        }
   

        public async Task<PagedResultDto<ValueTypeDataDto>> GetValueTypeDatasAsync(PagedValueTypeDataResultRequestDto input)
        {

            var listOfValueTypeDatas =  _valueTypeDataManager.GetAll();
            var query = listOfValueTypeDatas;

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
            var ValueTypeDatas = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ValueTypeDataDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ValueTypeDataDto>>(ValueTypeDatas)
            };

        }

        public async  Task<ValueTypeDataDto> CreateAsync(CreateValueTypeDataDto input)
        {
    
            var valueTypeData = await _valueTypeDataRepository.FirstOrDefaultAsync(app => app.Name == input.Name);

            if(valueTypeData != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingValueTypeData"));
            }
            
            valueTypeData = _mapper.Map<ValueTypeData>(input);
            await _valueTypeDataManager.CreateAsync(valueTypeData);
            return _mapper.Map<ValueTypeData, ValueTypeDataDto>(valueTypeData);
           
        }

        public async Task<ValueTypeDataDto> UpdateAsync(ValueTypeDataDto input)
        {
            var valueTypeData = await _valueTypeDataRepository.GetAsync(input.Id);
            if (valueTypeData == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingValueTypeData"));
            }

            valueTypeData = _mapper.Map<ValueTypeData>(input);
            await _valueTypeDataManager.UpdateAsync(valueTypeData);
            return _mapper.Map<ValueTypeData, ValueTypeDataDto>(valueTypeData);

        }

        public async Task DeleteAsync(int id)
        {
            await _valueTypeDataManager.DeleteAsync(id);
        }

    


    }
}
