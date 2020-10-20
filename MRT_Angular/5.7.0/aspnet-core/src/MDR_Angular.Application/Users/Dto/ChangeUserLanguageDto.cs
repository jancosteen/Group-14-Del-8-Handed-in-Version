using System.ComponentModel.DataAnnotations;

namespace MDR_Angular.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}