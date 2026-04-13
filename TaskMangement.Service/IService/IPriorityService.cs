using TaskMangement.Data.Models;

namespace TaskMangement.Service.IService
{
    public interface IPriorityService
    {
        Task<IEnumerable<Priority>> GetAllAsync();
        Task<Priority?> GetByIdAsync(long id);
        Task<Priority> CreateAsync(Priority Priority);
        Task<Priority?> UpdateAsync(long id, Priority Priority);
        Task<Priority?> DeleteAsync(long id);
    }
}