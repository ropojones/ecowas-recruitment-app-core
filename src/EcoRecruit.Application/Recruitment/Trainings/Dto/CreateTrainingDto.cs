using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Trainings.Dto
{
    [AutoMapTo(typeof(ApplicantTraining))]
    public class CreateTrainingDto 
    {
        public string Organization { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ApplicantId { get; set; }
    }

    
}
