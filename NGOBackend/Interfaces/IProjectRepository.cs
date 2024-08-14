using NGOBackend.Dtos.Project;
using NGOBackend.Models;

namespace NGOBackend.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project projectModel);
        Task<Project> UpdateAsync(int id, UpdateProjectRequestDto projectModel);
        Task<Project> DeleteAsync(int id);
    }
}
