using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.DTOs
{
    public class UserForLoginDto
    {
        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(12, MinimumLength = 6,  ErrorMessage="You must specify password between 6 to 12 characters")]
        public string Password {get; set;}
    }
}