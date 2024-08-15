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
                Users = projectModel.UserProjects.Select(up => new UserProjectsDto
                {
                    Username = up.User.Username,
                    Email = up.User.Email
                }).ToList()
                
            };
        }

        public static Project ToProjectFromCreate(this CreateProjectRequestDto projectModel)
        {
            return new Project
            { 
               ProjectId = projectModel.ProjectId,
               Name = projectModel.Name,
               StartDate = projectModel.StartDate,
               EndDate = projectModel.EndDate
            };
        }
    }
}
