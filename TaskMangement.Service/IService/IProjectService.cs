using TaskMangement.Data.Models;

namespace TaskMangement.Service.IService
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(long id);
        Task<Project> CreateAsync(Project project);
        Task<Project?> UpdateAsync(long id, Project project);
        Task<Project?> DeleteAsync(long id);
    }
}