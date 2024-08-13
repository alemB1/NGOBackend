using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.User;
using NGOBackend.Interfaces;
using NGOBackend.Mappers;
using NGOBackend.Models;

namespace NGOBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext dBContext, IUserRepository userRepo)
        {
            _context = dBContext;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            //var usersDto = users.Select(s => s.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            /*
             ovo stvara gresku zbog necega ali radi mi funkcija ako ista

            var userWithProjects = await _userRepo.GetUserWithProjectsAsync(id);

            if (userWithProjects != null) {
                foreach (var userProject in userWithProjects.UserProjects) {
                    Console.WriteLine(userProject.Project.Name);
                }
            }
           */

            var user = await _context.Users.FindAsync(id); // async call instead of firstordefault

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreate();
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = userModel.UserId }, userModel.ToUserDto());
            // automatski mapira sve
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id); // fetch the user by id

            if(userModel == null) return NotFound();

            userModel.Email = userDto.Email;
            userModel.Username = userDto.Username;

            await _context.SaveChangesAsync();
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if(userModel == null) return NotFound();
            
            // async doesnt go on delete
            _context.Users.Remove(userModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
