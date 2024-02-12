using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.CoverLetters.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.CoverLetters.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CoverLetters
{
    public class CoverLetterAppService : ApplicationService, ICoverLetterAppService
    {
        private readonly IRepository<ApplicantCoverLetter, long> _coverletterRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly CoverLetterManager _coverletterManager;

        public CoverLetterAppService(IRepository<ApplicantCoverLetter, long> coverletterRepository, IMapper mapper, ILocalizationManager localization, CoverLetterManager coverletterManager)
        {
          _coverletterRepository = coverletterRepository;
            _mapper = mapper;
            _localization = localization;
            _coverletterManager = coverletterManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<CoverLetterDto> GetCoverLetterAsync(long id)
        {
            var coverletter = await _coverletterRepository.GetAsync(id);
            return _mapper.Map<ApplicantCoverLetter, CoverLetterDto>(coverletter);

        }
   

        public async Task<PagedResultDto<CoverLetterDto>> GetCoverLettersAsync(PagedCoverLetterResultRequestDto input)
        {

            var listOfCoverLetters =  _coverletterManager.GetAll();
            var query = listOfCoverLetters;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "CoverLetterName")
                        {
                            query = query.Where(app => app.Letter.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "CoverLetterName":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Letter) : query.OrderByDescending(a => a.Letter);
                        break;
                   
                    default:
                        break;
                }
            }
            var CoverLetters = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<CoverLetterDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<CoverLetterDto>>(CoverLetters)
            };

        }

        public async  Task<CoverLetterDto> CreateAsync(CreateCoverLetterDto input)
        {
    
            var coverletter = await _coverletterRepository.FirstOrDefaultAsync(app => app.Letter == input.Letter && app.ApplicantId == input.ApplicantId);

            if(coverletter != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingCoverLetter"));
            }
            
            coverletter = _mapper.Map<ApplicantCoverLetter>(input);
            await _coverletterManager.CreateAsync(coverletter);
            return _mapper.Map<ApplicantCoverLetter, CoverLetterDto>(coverletter);
           
        }

        public async Task<CoverLetterDto> UpdateAsync(CoverLetterDto input)
        {
            var coverletter = await _coverletterRepository.GetAsync(input.Id);
            if (coverletter == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingCoverLetter"));
            }

            coverletter = _mapper.Map<ApplicantCoverLetter>(input);
            await _coverletterManager.UpdateAsync(coverletter);
            return _mapper.Map<ApplicantCoverLetter, CoverLetterDto>(coverletter);

        }

        public async Task DeleteAsync(long id)
        {
            await _coverletterManager.DeleteAsync(id);
        }

    


    }
}
