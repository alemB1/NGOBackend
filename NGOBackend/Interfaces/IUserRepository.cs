using NGOBackend.Dtos.User;
using NGOBackend.Models;

namespace NGOBackend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto);
        Task<User> DeleteAsync(int id);
        Task<User>? GetUserWithProjectsAsync(int userId);
    }
}
