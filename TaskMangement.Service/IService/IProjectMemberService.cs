using TaskMangement.Data.Models;

namespace TaskMangement.Service.IService
{
    public interface IProjectMemberService
    {
        Task<IEnumerable<ProjectMember>> GetAllAsync();

        Task<ProjectMember?> GetByIdAsync(long id);

        Task<ProjectMember> CreateAsync(ProjectMember projectMember);

        Task<ProjectMember?> UpdateAsync(long id, ProjectMember projectMember);

        Task<ProjectMember?> DeleteAsync(long id);
    }
}