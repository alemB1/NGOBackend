using NGOBackend.Dtos.Project;
using NGOBackend.Dtos.User;
using NGOBackend.Models;

namespace NGOBackend.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                Username = userModel.Username,
                Email = userModel.Email,
                Projects = userModel.UserProjects?.Select(up => new ProjectUsersDto {
                    ProjectId = up.Project.ProjectId,
                    Name = up.Project.Name,
                    StartDate = up.Project.StartDate,
                    EndDate = up.Project.EndDate
                }).ToList() ?? new List<ProjectUsersDto> { }
                // null handling for new objects
            };
        }


        public static User ToUserFromCreate(this CreateUserRequestDto userModel)
        {
            return new User
            {
                Email = userModel.Email,
                Username = userModel.Username,
                Projects = new List<Project>()
            };
        }
    }
}
