using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service
{
    public class TaskService(AppDbContext context) : IITaskService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Data.Models.Task>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Data.Models.Task?> GetByIdAsync(long id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Data.Models.Task> CreateAsync(Data.Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Data.Models.Task?> UpdateAsync(long id, Data.Models.Task task)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.DuDate = task.DuDate;
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<Data.Models.Task?> DeleteAsync(long id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return null;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}