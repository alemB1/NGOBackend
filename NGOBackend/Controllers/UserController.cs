using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Mappers;
using NGOBackend.Models;

namespace NGOBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.UserProjects.ToListAsync();
            // fix this
            /*
             U sustini users controller nece imati prikaz projekata
            nego ce samo to imati userproject
            ovo ce opet imati crud ali ako korisnik zeli promjeniti projekat ili dodati/oktazati mora imati auth pravilan za to(jwt)
             
             */
            return Ok(users);
        }
       

        


    }
}
