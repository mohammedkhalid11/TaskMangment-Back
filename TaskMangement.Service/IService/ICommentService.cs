using TaskMangement.Data.Models;

namespace TaskMangement.Service.IService
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(long id);

        Task<Comment> CreateAsync(Comment comment);

        Task<Comment?> UpdateAsync(long id, Comment comment);

        Task<Comment?> DeleteAsync(long id);
    }
}