using System.ComponentModel.DataAnnotations;

namespace TaskMangement.Data.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //public ICollection<ProjectMember> ProjectMembers { get; set; }
        //public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}