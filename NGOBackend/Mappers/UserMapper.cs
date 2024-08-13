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
                Projects = null
            };
        }

        public static User ToUserFromCreate(this CreateUserRequestDto userModel)
        {
            return new User
            {
                UserId = userModel.UserId,
                Email = userModel.Email,
                Username = userModel.Username
            };
        }
    }
}
