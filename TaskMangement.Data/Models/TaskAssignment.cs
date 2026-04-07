using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangement.Data.Models
{
    public class TaskAssignment
    {
        [Key]
        public long Id { get; set; }

        public long TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task? Task { get; set; }

        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}