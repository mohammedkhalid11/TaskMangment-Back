using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service
{
    public class PriorityService(AppDbContext context) : IPriorityService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            return await _context.Priorities.ToListAsync();
        }

        public async Task<Priority?> GetByIdAsync(long id)
        {
            return await _context.Priorities.FindAsync(id);
        }

        public async Task<Priority> CreateAsync(Priority Priority)
        {
            await _context.Priorities.AddAsync(Priority);
            await _context.SaveChangesAsync();
            return Priority;
        }

        public async Task<Priority?> UpdateAsync(long id, Priority Priority)
        {
            var existingPriority = await _context.Priorities.FindAsync(id);
            if (existingPriority == null) return null;


            existingPriority.Name = Priority.Name;
            existingPriority.ReminderTime = Priority.ReminderTime;

            await _context.SaveChangesAsync();
            return existingPriority;
        }

        public async Task<Priority?> DeleteAsync(long id)
        {
            var Priority = await _context.Priorities.FindAsync(id);
            if (Priority == null) return null;

            _context.Priorities.Remove(Priority);
            await _context.SaveChangesAsync();
            return Priority;
        }
    }
}