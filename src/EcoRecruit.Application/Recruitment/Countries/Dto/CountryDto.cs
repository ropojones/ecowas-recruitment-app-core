using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Countries;

namespace EcoRecruit.Application.Recruitment.Countries.Dto
{
    [AutoMapFrom(typeof(Country))]
    public class CountryDto : Entity<int>
    {

        public string CountryName { get; set; }

    }
}