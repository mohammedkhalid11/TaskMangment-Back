using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangement.Data.Models
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public long TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task? Task { get; set; }
    }
}