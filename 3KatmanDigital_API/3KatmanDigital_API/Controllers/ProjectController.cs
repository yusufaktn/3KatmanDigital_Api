using _3katman_digital_mvc.Models;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3KatmanDigital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,new
                {
                    Message = ex.Message
                    
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the project.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project cannot be null.");
            }
            try
            {
                var createdProject = await _projectService.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.ID }, createdProject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the project.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] Project project)
        {
            if (project == null || project.ID != id)
            {
                return BadRequest("Project data is invalid.");
            }
            try
            {
                var updatedProject = await _projectService.UpdateProjectAsync(project);
                if (updatedProject == null)
                {
                    return NotFound();
                }
                return Ok(updatedProject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the project.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            try
            {
                var isDeleted = await _projectService.DeleteProjectAsync(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the project.");
            }


        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProjectsByCategoryId(Guid categoryId)
        {
            try
            {
                var projects = await _projectService.GetProjectsByCategoryIdAsync(categoryId);
                if (projects == null || !projects.Any())
                {
                    return NotFound();
                }
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving projects by category.");
            }
        }
    }
}
