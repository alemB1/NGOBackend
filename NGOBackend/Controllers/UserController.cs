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
            var user = await _userRepo.GetAllAsync();
            var userDto = user.Select(u => u.ToUserDto()).ToList();
            return Ok(userDto); // return the dto until you fix the model
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // test
           

            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreate();
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
        {
            var userModel = await _userRepo.UpdateAsync(id, userDto);
            if (userModel == null) return NotFound();
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var userModel = await _userRepo.DeleteAsync(id);
            if (userModel == null) return NotFound();
            return NoContent();
        }
    }
}
