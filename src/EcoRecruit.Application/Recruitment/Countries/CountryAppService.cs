using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Countries.Dto;
using EcoRecruit.Recruitment.Countries;
using EcoRecruit.Recruitment.Countries.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Countrys
{
    public class CountryAppService : ApplicationService, ICountryAppService
    {
        private readonly IRepository<Country, int> _countryRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly CountryManager _countryManager;

        public CountryAppService(IRepository<Country, int> countryRepository, IMapper mapper, ILocalizationManager localization, CountryManager countryManager)
        {
          _countryRepository = countryRepository;
            _mapper = mapper;
            _localization = localization;
            _countryManager = countryManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<CountryDto> GetCountryAsync(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            return _mapper.Map<Country, CountryDto>(country);

        }
   

        public async Task<PagedResultDto<CountryDto>> GetCountriesAsync(PagedCountryResultRequestDto input)
        {

            var listOfCountrys =  _countryManager.GetAll();
            var query = listOfCountrys;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "CountryName")
                        {
                            query = query.Where(app => app.CountryName.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "CountryName":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.CountryName) : query.OrderByDescending(a => a.CountryName);
                        break;
                   
                    default:
                        break;
                }
            }
            var Countrys = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<CountryDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<CountryDto>>(Countrys)
            };

        }

        public async  Task<CountryDto> CreateAsync(CreateCountryDto input)
        {
    
            var country = await _countryRepository.FirstOrDefaultAsync(app => app.CountryName == input.CountryName);

            if(country != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingCountry"));
            }
            
            country = _mapper.Map<Country>(input);
            await _countryManager.CreateAsync(country);
            return _mapper.Map<Country, CountryDto>(country);
           
        }

        public async Task<CountryDto> UpdateAsync(CountryDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
            if (country == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingCountry"));
            }

            country = _mapper.Map<Country>(input);
            await _countryManager.UpdateAsync(country);
            return _mapper.Map<Country, CountryDto>(country);

        }

        public async Task DeleteAsync(int id)
        {
            await _countryManager.DeleteAsync(id);
        }

    


    }
}
