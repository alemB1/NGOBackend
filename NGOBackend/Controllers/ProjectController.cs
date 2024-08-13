using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.Project;
using NGOBackend.Mappers;

namespace NGOBackend.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProjectController(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _context.Projects.ToListAsync();
            var projectsDto = projects.Select(p => p.ToProjectDto());
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.ProjectId == id);
            if (project == null) return NotFound();

            return Ok(project);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectDto)
        {
            var projectModel = projectDto.ToProjectFromCreate();
            await _context.Projects.AddAsync(projectModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = projectModel.ProjectId }, projectModel.ToProjectDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectRequestDto projectDto)
        {
            var projectModel = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

            if (projectModel == null) return NotFound();

            projectModel.Name = projectDto.Name;
            projectModel.StartDate = projectDto.StartDate;
            projectModel.StartDate = projectDto.EndDate;

            await _context.SaveChangesAsync();
            return Ok(projectModel.ToProjectDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var projectModel = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (projectModel == null) return NotFound();

            _context.Projects.Remove(projectModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
