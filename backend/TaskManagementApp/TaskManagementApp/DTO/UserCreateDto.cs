using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.DTO
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } // Plain text password to be hashed

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
