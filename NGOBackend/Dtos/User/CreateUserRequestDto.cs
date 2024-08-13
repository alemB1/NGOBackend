namespace NGOBackend.Dtos.User
{
    public class CreateUserRequestDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
