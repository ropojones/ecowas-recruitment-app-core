using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Authorization;
using EcoRecruit.Recruitment.Applicants.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{

    public class ApplicantAppService : ApplicationService, IApplicantAppService
    {
        private readonly IRepository<Applicant, long> _applicantRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ApplicantManager _applicantManager;

        public ApplicantAppService(IRepository<Applicant, long> applicantRepository, IMapper mapper, ILocalizationManager localization, ApplicantManager applicantManager)
        {
          _applicantRepository = applicantRepository;
            _mapper = mapper;
            _localization = localization;
            _applicantManager = applicantManager;
            LocalizationSourceName = "EcoRecruit";            
        }

        public async Task<ApplicantDto> GetApplicantAsync(long id)
        {
            var applicant = await _applicantRepository.GetAsync(id);
            return _mapper.Map<Applicant, ApplicantDto>(applicant);
        }
        public async Task<ApplicantDto> GetApplicantUserIdAsync(long id)
        {
            var applicant =  await _applicantRepository.FirstOrDefaultAsync(app => app.UserId == id); ;
            if (applicant != null)
            {
                return _mapper.Map<Applicant, ApplicantDto>(applicant);
            }else
            {
                throw new UserFriendlyException("Not found!");
            }
           

        }
        public async Task<ApplicantDto> GetApplicantByAppNoAsync(string AppNo)
        {
            var applicant = await _applicantRepository.FirstOrDefaultAsync(app => app.ApplicantNumber == AppNo);
            return _mapper.Map<Applicant, ApplicantDto>(applicant);
        }

        public async Task<PagedResultDto<ApplicantDto>> GetApplicantsAsync(PagedApplicantResultRequestDto input)
        {

            var listOfApplicants =  _applicantManager.GetAll();
            var query = listOfApplicants;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Firstname")
                        {
                            query = query.Where(app => app.FirstName.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "Fastname")
                        {
                            query = query.Where(app => app.LastName.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "Email")
                        {
                            query = query.Where(app => app.Email.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "Phone")
                        {
                            query = query.Where(app => app.Phone.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Firstname":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.FirstName) : query.OrderByDescending(a => a.FirstName);
                        break;
                    case "Lastname":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.LastName) : query.OrderByDescending(a => a.LastName);
                        break;
                    default:
                        break;
                }
            }
            var applicants = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ApplicantDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ApplicantDto>>(applicants)

            };

        }

        public async  Task<ApplicantDto> CreateAsync(CreateApplicantDto input)
        {
    
            var applicant = await _applicantRepository.FirstOrDefaultAsync(app => app.Email == input.Email);

            if(applicant != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingApplicantEmail"));
            }
            
            applicant = _mapper.Map<Applicant>(input);
            await _applicantManager.CreateAsync(applicant);
            return _mapper.Map<Applicant, ApplicantDto>(applicant);
           
        }

        public async Task<ApplicantDto> UpdateAsync(ApplicantDto input)
        {
            var applicant = await _applicantRepository.GetAsync(input.Id);
            if (applicant == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingApplicant"));
            }

            applicant = _mapper.Map<Applicant>(input);
            await _applicantManager.UpdateAsync(applicant);
            return _mapper.Map<Applicant, ApplicantDto>(applicant);

        }

        public async Task DeleteAsync(long id)
        {
            await _applicantManager.DeleteAsync(id);
        }

        public async Task <bool> IsCreated(long userId)
        {
            return await  _applicantManager.IsCreated(userId);
        }
    }
}
