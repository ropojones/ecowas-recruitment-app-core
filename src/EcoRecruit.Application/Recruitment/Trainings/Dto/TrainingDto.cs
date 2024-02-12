using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Application.Recruitment.Trainings.Dto
{
    
    [AutoMapFrom(typeof(ApplicantTraining))]
    public class TrainingDto: EntityDto<long>
    {
        public string Organization { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ApplicantId { get; set; }
    }
}