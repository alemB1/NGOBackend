using System.ComponentModel.DataAnnotations;

namespace NGOBackend.Dtos.Project
{
    public class UpdateProjectRequestDto
    {
        [Required]
        [MaxLength(120, ErrorMessage = "Project name can not exceed the limit of 120 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
