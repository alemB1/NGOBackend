using NGOBackend.Dtos.Project;

namespace NGOBackend.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<ProjectDto> Projects { get; set; } = null;
    }
}
