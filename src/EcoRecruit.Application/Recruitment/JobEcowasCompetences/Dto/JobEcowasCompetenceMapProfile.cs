using AutoMapper;
using EcoRecruit.Application.Recruitment.JobEcowasCompetences.Dto;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Recruitment.JobEcowasCompetences.Dto
{
    public class JobEcowasCompetenceMapProfile : Profile
    {
        public JobEcowasCompetenceMapProfile()
        {
            CreateMap<CreateJobEcowasCompetenceDto, JobEcowasCompetence>();
            CreateMap<JobEcowasCompetenceDto, JobEcowasCompetence>();
            CreateMap<JobEcowasCompetence, JobEcowasCompetenceDto>();
            
        }
    }
}
