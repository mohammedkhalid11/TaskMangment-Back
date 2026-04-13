using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service
{
    public class CommentService(AppDbContext context) : ICommentService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(long id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateAsync(long id, Comment comment)
        {
            var existingComment = await _context.Comment.FindAsync(id);
            if (existingComment == null) return null;

            existingComment.Content = comment.Content;
          
            await _context.SaveChangesAsync();
            return existingComment;
        }
        public async Task<Comment?> DeleteAsync(long id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null) return null;

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
