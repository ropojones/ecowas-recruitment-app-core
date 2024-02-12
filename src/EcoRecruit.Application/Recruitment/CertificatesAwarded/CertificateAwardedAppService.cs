using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.CertificateAwardeds;
using EcoRecruit.Recruitment.CertificatesAwarded.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CertificatesAwarded
{
    public class CertificateAwardedAppService : ApplicationService, ICertificateAwardedAppService
    {
        private readonly IRepository<ApplicantCertificateAwarded, long> _certificateAwardedRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly CertificateAwardedManager _certificateAwardedManager;

        public CertificateAwardedAppService(IRepository<ApplicantCertificateAwarded, long> certificateAwardedRepository, IMapper mapper, ILocalizationManager localization, CertificateAwardedManager certificateAwardedManager)
        {
          _certificateAwardedRepository = certificateAwardedRepository;
            _mapper = mapper;
            _localization = localization;
            _certificateAwardedManager = certificateAwardedManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<CertificateAwardedDto> GetCertificateAwardedAsync(long id)
        {
            var certificateAwarded = await _certificateAwardedRepository.GetAsync(id);
            return _mapper.Map<ApplicantCertificateAwarded, CertificateAwardedDto>(certificateAwarded);

        }
   

        public async Task<PagedResultDto<CertificateAwardedDto>> GetCertificateAwardedsAsync(PagedCertificateAwardedResultRequestDto input)
        {

            var listOfCertificateAwardeds =  _certificateAwardedManager.GetAll();
            var query = listOfCertificateAwardeds;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Title")
                        {
                            query = query.Where(app => app.Title.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "Type")
                        {
                            query = query.Where(app => app.Type.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "YearReceived")
                        {
                            query = query.Where(app => app.YearReceived== searchParam[1] || searchParam[1] == "");
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
                    case "Title":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title);
                        break;
                    case "Type":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Type) : query.OrderByDescending(a => a.Title);
                        break;
                    default:
                        break;
                }
            }
            var CertificateAwardeds = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<CertificateAwardedDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<CertificateAwardedDto>>(CertificateAwardeds)
            };

        }

        public async  Task<CertificateAwardedDto> CreateAsync(CreateCertificateAwardedDto input)
        {
    
            var certificateAwarded = await _certificateAwardedRepository.FirstOrDefaultAsync(app => app.Title == input.Title && app.ApplicantId == input.ApplicantId);

            if(certificateAwarded != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingCertificate"));
            }
            
            certificateAwarded = _mapper.Map<ApplicantCertificateAwarded>(input);
            await _certificateAwardedManager.CreateAsync(certificateAwarded);
            return _mapper.Map<ApplicantCertificateAwarded, CertificateAwardedDto>(certificateAwarded);
           
        }

        public async Task<CertificateAwardedDto> UpdateAsync(CertificateAwardedDto input)
        {
            var certificateAwarded = await _certificateAwardedRepository.GetAsync(input.Id);
            if (certificateAwarded == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingCertificate"));
            }

            certificateAwarded = _mapper.Map<ApplicantCertificateAwarded>(input);
            await _certificateAwardedManager.UpdateAsync(certificateAwarded);
            return _mapper.Map<ApplicantCertificateAwarded, CertificateAwardedDto>(certificateAwarded);

        }

        public async Task DeleteAsync(long id)
        {
            await _certificateAwardedManager.DeleteAsync(id);
        }

    


    }
}
