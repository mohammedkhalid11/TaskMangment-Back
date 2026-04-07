using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangement.Data.Models
{
    public class ProjectMember
    {
        [Key]
        public long Id { get; set; }

        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        //public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();
        //public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        //public ICollection<FileAttachment> Files { get; set; }
    }
}