using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.Project;
using NGOBackend.Helpers;
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

        public async Task<List<Project>> GetAllAsync(QueryObjectProject query)
        {
            //cant use the asqueryable with the async call to the db
            var projects = _context.Projects
            .Include(u => u.UserProjects)
            .ThenInclude(up => up.User)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                projects = projects.Where(p => p.Name.Contains(query.Name));
            }

            if (query.StartDate.HasValue)
            {
                projects = projects.Where(p => p.StartDate >= query.StartDate);
            }

            if (query.EndDate.HasValue)
            {
                projects = projects.Where(p => p.EndDate <= query.EndDate);
            }

            // implement date sorting 

            return await projects.ToListAsync();
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
