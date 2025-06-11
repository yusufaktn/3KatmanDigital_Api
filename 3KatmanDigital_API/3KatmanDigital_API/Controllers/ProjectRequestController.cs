using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3KatmanDigital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRequestController : ControllerBase
    {
        private readonly IProjectRequestService _projectRequestService;
        public ProjectRequestController(IProjectRequestService projectRequestService)
        {
            _projectRequestService = projectRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectRequests()
        {
            try
            {
                var projectRequests = await _projectRequestService.GetAllProjectRequestsAsync();
                return Ok(projectRequests);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving project requests.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectRequestById(Guid id)
        {
            try
            {
                var projectRequest = await _projectRequestService.GetProjectRequestByIdAsync(id);
                if (projectRequest == null)
                {
                    return NotFound();
                }
                return Ok(projectRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the project request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProjectRequest([FromBody] ProjectRequest projectRequest)
        {
            if (projectRequest == null)
            {
                return BadRequest("Project request cannot be null.");
            }
            try
            {
                var createdProjectRequest = await _projectRequestService.AddProjectRequestAsync(projectRequest);
                return CreatedAtAction(nameof(GetProjectRequestById), new { id = createdProjectRequest.ID }, createdProjectRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the project request.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectRequest(Guid id, [FromBody] ProjectRequest projectRequest)
        {
            if (projectRequest == null || projectRequest.ID != id)
            {
                return BadRequest("Project request is null or ID mismatch.");
            }
            try
            {
                var updatedProjectRequest = await _projectRequestService.UpdateProjectRequestAsync(projectRequest);
                if (updatedProjectRequest == null)
                {
                    return NotFound();
                }
                return Ok(updatedProjectRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the project request.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectRequest(Guid id)
        {
            try
            {
                var isDeleted = await _projectRequestService.DeleteProjectRequestAsync(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the project request.");
            }
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProjectRequestsByCategoryId(Guid categoryId)
        {
            try
            {
                var projectRequests = await _projectRequestService.GetProjectRequestsByCategoryIdAsync(categoryId);
                return Ok(projectRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving project requests by category.");
            }

        }

    }
}
