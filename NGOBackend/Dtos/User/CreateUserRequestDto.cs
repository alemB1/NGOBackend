using System.ComponentModel.DataAnnotations;

namespace NGOBackend.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Username has to be atleast 3 characters")]
        [MaxLength(50, ErrorMessage ="Username cant be over 50 characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
