using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.User;
using NGOBackend.Interfaces;
using NGOBackend.Mappers;
using NGOBackend.Models;

namespace NGOBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User>? GetUserWithProjectsAsync(int userId)
        {
            return await _context.Users
               .Include(u => u.UserProjects)
               .ThenInclude(up => up.Project)
               .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
