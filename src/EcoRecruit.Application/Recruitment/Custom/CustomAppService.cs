using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Customs.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Customs.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace EcoRecruit.Recruitment.Customs
{
    public class CustomAppService : ApplicationService, ICustomAppService
    {
        private readonly IRepository<ApplicantCustom, long> _customRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly CustomManager _customManager;

        public CustomAppService(IRepository<ApplicantCustom, long> customRepository, IMapper mapper, ILocalizationManager localization, CustomManager customManager)
        {
          _customRepository = customRepository;
            _mapper = mapper;
            _localization = localization;
            _customManager = customManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<CustomDto> GetCustomAsync(long id)
        {
            var custom = await _customRepository.GetAsync(id);
            return _mapper.Map<ApplicantCustom, CustomDto>(custom);

        }
   

        public async Task<PagedResultDto<CustomDto>> GetCustomsAsync(PagedCustomResultRequestDto input)
        {

            var listOfCustoms =  _customManager.GetAll();
            var query = listOfCustoms;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "CustomInfo")
                        {
                            query = query.Where(app => app.CustomInfo.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "CustomName":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.CustomInfo) : query.OrderByDescending(a => a.CustomInfo);
                        break;
                   
                    default:
                        break;
                }
            }
            var Customs = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<CustomDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<CustomDto>>(Customs)
            };

        }

        public async  Task<CustomDto> CreateAsync(CreateCustomDto input)
        {
            var custom = await _customRepository.FirstOrDefaultAsync(app => app.CustomInfo == input.CustomInfo && app.ApplicantId == input.ApplicantId);

            if (custom != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingCustom"));
            }


            custom = _mapper.Map<ApplicantCustom>(input);
            await _customManager.CreateAsync(custom);
            return _mapper.Map<ApplicantCustom, CustomDto>(custom);
           
        }

        public async Task<CustomDto> UpdateAsync(CustomDto input)
        {
            var custom = await _customRepository.GetAsync(input.Id);
            if (custom == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingCustom"));
            }

            custom = _mapper.Map<ApplicantCustom>(input);
            await _customManager.UpdateAsync(custom);
            return _mapper.Map<ApplicantCustom, CustomDto>(custom);

        }

        public async Task DeleteAsync(long id)
        {
            await _customManager.DeleteAsync(id);
        }

    }
}
