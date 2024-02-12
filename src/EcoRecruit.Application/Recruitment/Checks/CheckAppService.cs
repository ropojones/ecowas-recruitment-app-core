using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Recruitment.Checks;
using EcoRecruit.Recruitment.Checks.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks
{
    public class CheckAppService : ApplicationService, ICheckAppService
    {
        private readonly IRepository<Check, int> _checkRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly CheckManager _checkManager;

        public CheckAppService(IRepository<Check, int> checkRepository, IMapper mapper, ILocalizationManager localization, CheckManager checkManager)
        {
          _checkRepository = checkRepository;
            _mapper = mapper;
            _localization = localization;
            _checkManager = checkManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<CheckDto> GetCheckAsync(int id)
        {
            var check = await _checkRepository.GetAsync(id);
            return _mapper.Map<Check, CheckDto>(check);

        }
             public async Task<PagedResultDto<CheckDto>> GetChecksAsync(PagedCheckResultRequestDto input)
        {

            var listOfChecks =  _checkManager.GetAll();
            var query = listOfChecks;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Description")
                        {
                            query = query.Where(app => app.Description.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Description":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Description) : query.OrderByDescending(a => a.Description);
                        break;
                          default:
                        break;
                }
            }
            var Checks = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<CheckDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<CheckDto>>(Checks)
            };

        }

        public async  Task<CheckDto> CreateAsync(CreateCheckDto input)
        {
    
            var check = await _checkRepository.FirstOrDefaultAsync(app => app.Description == input.Description);

            if(check != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingCheck"));
            }
            
            check = _mapper.Map<Check>(input);
            await _checkManager.CreateAsync(check);
            return _mapper.Map<Check, CheckDto>(check);
           
        }

        public async Task<CheckDto> UpdateAsync(CheckDto input)
        {
            var check = await _checkRepository.GetAsync(input.Id);
            if (check == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingCheck"));
            }

            check = _mapper.Map<Check>(input);
            await _checkManager.UpdateAsync(check);
            return _mapper.Map<Check, CheckDto>(check);

        }

        public async Task DeleteAsync(int id)
        {
            await _checkManager.DeleteAsync(id);
        }

    


    }
}
