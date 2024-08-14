using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOBackend.Data;
using NGOBackend.Dtos.Project;
using NGOBackend.Interfaces;
using NGOBackend.Mappers;
using System.Runtime.InteropServices;

namespace NGOBackend.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProjectRepository _projectRepo;
        public ProjectController(ApplicationDBContext dBContext, IProjectRepository projectRepo)
        {
            _context = dBContext;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var project = await _projectRepo.GetAllAsync();
            var projectDto = project.Select(p => p.ToProjectDto()).ToList(); // dto mapping goes here not in the interface\
            return Ok(projectDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project.ToProjectDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectDto)
        {
            var projectModel = projectDto.ToProjectFromCreate();
            await _projectRepo.CreateAsync(projectModel);
            return CreatedAtAction(nameof(GetById), new { id = projectModel.ProjectId }, projectModel.ToProjectDto()); ;
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectRequestDto projectDto)
        {
            var projectModel = await _projectRepo.UpdateAsync(id, projectDto);
            if(projectModel == null) return NotFound();
            return Ok(projectModel.ToProjectDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var projectModel = await _projectRepo.DeleteAsync(id);
            if(projectModel == null) return NotFound();
            return NoContent();
        }
    }
}
