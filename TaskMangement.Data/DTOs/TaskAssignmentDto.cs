namespace TaskMangement.Data.DTOs
{
    public class TaskAssignmentDto
    {
        public long TaskId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}