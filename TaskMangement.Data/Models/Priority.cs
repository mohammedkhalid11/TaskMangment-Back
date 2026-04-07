using System.ComponentModel.DataAnnotations;

namespace TaskMangement.Data.Models
{
    public class Priority
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}