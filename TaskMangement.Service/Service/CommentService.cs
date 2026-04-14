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
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(long id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            comment.Task = null;

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateAsync(long id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null) return null;

            existingComment.Content = comment.Content;

            _context.Comments.Update(existingComment);
            await _context.SaveChangesAsync();
            return existingComment;
        }

        public async Task<Comment?> DeleteAsync(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
