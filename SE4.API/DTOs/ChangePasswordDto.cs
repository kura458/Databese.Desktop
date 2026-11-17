using System.ComponentModel.DataAnnotations;

namespace SE4.API.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = "";

        [Required]
        public string OldPassword { get; set; } = "";

        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; } = "";
    }
}
