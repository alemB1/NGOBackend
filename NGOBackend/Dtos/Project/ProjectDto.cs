using NGOBackend.Dtos.User;
using System.Text.Json.Serialization;
namespace NGOBackend.Dtos.Project
{
    public class ProjectDto
    {
        //for now the same as models
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<UserProjectsDto> Users { get; set; }
    }
}
