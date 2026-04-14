using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Data.DTOs;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service
{
    public class TaskAssignmentService(AppDbContext context) : ITaskAssignmentService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<TaskAssignment>> GetAllAsync()
        {
            return await _context.TaskAssignments.ToListAsync();
        }

        public async Task<TaskAssignment?> GetByIdAsync(long id)
        {
            return await _context.TaskAssignments.FindAsync(id);
        }

        public async Task<TaskAssignment> CreateAsync(TaskAssignmentDto dto)
        {
            var taskAssignment = new TaskAssignment
            {
                TaskId = dto.TaskId,
                UserId = dto.UserId
            };

            await _context.TaskAssignments.AddAsync(taskAssignment);
            await _context.SaveChangesAsync();
            return taskAssignment;
        }

        public async Task<TaskAssignment?> UpdateAsync(long id, TaskAssignment TaskAssignment)
        {
            var existingTaskAssignment = await _context.TaskAssignments.FindAsync(id);
            if (existingTaskAssignment == null) return null;

            existingTaskAssignment.TaskId = TaskAssignment.TaskId;
            existingTaskAssignment.UserId = TaskAssignment.UserId;
            await _context.SaveChangesAsync();
            return existingTaskAssignment;
        }

        public async Task<TaskAssignment?> DeleteAsync(long id)
        {
            var TaskAssignment = await _context.TaskAssignments.FindAsync(id);
            if (TaskAssignment == null) return null;

            _context.TaskAssignments.Remove(TaskAssignment);
            await _context.SaveChangesAsync();
            return TaskAssignment;
        }
    }
}