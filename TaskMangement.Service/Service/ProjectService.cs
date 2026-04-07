using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service;

public class ProjectService(AppDbContext context) : IProjectService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(long id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<Project> CreateAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project?> UpdateAsync(long id, Project project)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject == null) return null;

        existingProject.Name = project.Name;
        existingProject.Description = project.Description;
        await _context.SaveChangesAsync();
        return existingProject;
    }

    public async Task<Project?> DeleteAsync(long id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null) return null;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }
}
