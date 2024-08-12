using NGOBackend.Dtos.User;
namespace NGOBackend.Dtos.Project
{
    public class ProjectDto
    {
        //for now the same as models
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<UserDto> Users { get; set; } = null;

    }
}
