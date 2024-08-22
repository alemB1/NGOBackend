using NGOBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace NGOBackend.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        public int ProjectId { get; set; }
        [Required]
        [MaxLength(120,ErrorMessage = "Project name can not exceed the limit of 120 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
