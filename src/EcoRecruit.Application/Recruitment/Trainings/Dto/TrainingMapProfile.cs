using AutoMapper;
using EcoRecruit.Application.Recruitment.Trainings.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Trainings.Dto
{
    public class TrainingMapProfile : Profile
    {
        public TrainingMapProfile()
        {
            CreateMap<CreateTrainingDto, ApplicantTraining>();
            CreateMap<TrainingDto, ApplicantTraining>();
            CreateMap<ApplicantTraining, TrainingDto>();
            
        }
    }
}
