using TaskMangement.Data.Models;

namespace TaskMangement.Service.IService
{
    public interface ITaskAssignmentService
    {
        Task<IEnumerable<TaskAssignment>> GetAllAsync();
        Task<TaskAssignment?> GetByIdAsync(long id);
        Task<TaskAssignment> CreateAsync(TaskAssignment TaskAssignment);
        Task<TaskAssignment?> UpdateAsync(long id, TaskAssignment TaskAssignment);
        Task<TaskAssignment?> DeleteAsync(long id);
    }
}