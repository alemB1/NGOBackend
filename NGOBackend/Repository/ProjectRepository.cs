using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.Project;
using NGOBackend.Interfaces;
using NGOBackend.Models;

namespace NGOBackend.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDBContext _context;

        public ProjectRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Project> CreateAsync(Project projectModel)
        {
            await _context.Projects.AddAsync(projectModel);
            await _context.SaveChangesAsync();
            return projectModel;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null) return null;
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(u => u.UserProjects)
                .ThenInclude(up => up.User)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(u => u.UserProjects)
                .ThenInclude(up => up.User)
                .Where(p => p.ProjectId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Project> UpdateAsync(int id, UpdateProjectRequestDto projectDto)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null) return null;

            project.Name =projectDto.Name;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;

            await _context.SaveChangesAsync();
            return project;
        }
    }
}
