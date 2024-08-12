using NGOBackend.Dtos.Project;
using NGOBackend.Dtos.User;
using NGOBackend.Models;

namespace NGOBackend.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectDto ToProjectDto(this Project projectModel)
        {
            return new ProjectDto
            {
                ProjectId = projectModel.ProjectId,
                Name = projectModel.Name,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate,
                Users = null
            };
        }
    }
}
