using Microsoft.AspNetCore.Http.HttpResults;
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
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User> DeleteAsync(int id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.UserProjects)
                .ThenInclude(up => up.Project)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserProjects)
                .ThenInclude(up => up.Project)
                .Where(x => x.UserId == id)
                .FirstOrDefaultAsync();
            return user;
        }


        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (existingUser == null) return null;

            existingUser.Email = userDto.Email;
            existingUser.Username = userDto.Username;

            await _context.SaveChangesAsync();
            return existingUser;
        }

       
    }
}
