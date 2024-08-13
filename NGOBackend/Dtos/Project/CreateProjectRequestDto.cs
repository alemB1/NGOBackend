using NGOBackend.Models;

namespace NGOBackend.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
