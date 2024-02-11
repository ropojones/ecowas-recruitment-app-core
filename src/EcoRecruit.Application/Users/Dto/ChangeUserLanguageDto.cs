using System.ComponentModel.DataAnnotations;

namespace EcoRecruit.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}