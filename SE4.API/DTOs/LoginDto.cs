using System.ComponentModel.DataAnnotations;

namespace SE4.API.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = "";

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = "";
    }
}