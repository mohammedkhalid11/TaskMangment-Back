using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Models;

namespace TaskMangement.Data.Data
{
    public partial class AppDbContext
    {
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}