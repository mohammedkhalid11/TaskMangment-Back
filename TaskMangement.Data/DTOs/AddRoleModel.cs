using System.ComponentModel.DataAnnotations;

namespace TaskMangement.Data.DTOs
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}