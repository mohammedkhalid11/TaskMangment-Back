using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangement.Data.Models
{
    public class Task
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime DuDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        public long PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public Priority? Priority { get; set; }
    }
}