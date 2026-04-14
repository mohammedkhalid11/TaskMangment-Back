using Microsoft.EntityFrameworkCore;
using TaskMangement.Data.Data;
using TaskMangement.Data.DTOs;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.Service.Service;

public class ProjectMemberService(AppDbContext context) : IProjectMemberService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<ProjectMember>> GetAllAsync()
    {
        return await _context.ProjectMembers.ToListAsync();
    }

    public async Task<ProjectMember?> GetByIdAsync(long id)
    {
        return await _context.ProjectMembers.FindAsync(id);
    }

    public async Task<ProjectMember> CreateAsync(ProjectMemberDto dto)
    {
        var projectMember = new ProjectMember
        {
            ProjectId = dto.ProjectId,
            UserId = dto.UserId
        };

        await _context.ProjectMembers.AddAsync(projectMember);
        await _context.SaveChangesAsync();
        return projectMember;
    }

    public async Task<ProjectMember?> UpdateAsync(long id, ProjectMember projectMember)
    {
        var existingMember = await _context.ProjectMembers.FindAsync(id);
        if (existingMember == null) return null;

        existingMember.ProjectId = projectMember.ProjectId;
        existingMember.UserId = projectMember.UserId;

        await _context.SaveChangesAsync();
        return existingMember;
    }

    public async Task<ProjectMember?> DeleteAsync(long id)
    {
        var member = await _context.ProjectMembers.FindAsync(id);
        if (member == null) return null;

        _context.ProjectMembers.Remove(member);
        await _context.SaveChangesAsync();
        return member;
    }
}


