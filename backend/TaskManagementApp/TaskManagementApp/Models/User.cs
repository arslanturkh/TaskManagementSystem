using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
