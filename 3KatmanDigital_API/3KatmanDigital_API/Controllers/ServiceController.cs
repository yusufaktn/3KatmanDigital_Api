using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3KatmanDigital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService_Service _serviceService;
        public ServiceController(IService_Service serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var services = await _serviceService.GetAllServicesAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            try
            {
                var service = await _serviceService.GetServiceByIdAsync(id);
                if (service == null)
                {
                    return NotFound();
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the service.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest("Service cannot be null.");
            }
            try
            {
                var createdService = await _serviceService.AddServiceAsync(service);
                return CreatedAtAction(nameof(GetServiceById), new { id = createdService.ID }, createdService);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the service.");
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] Service service)
        {
            if (service == null || service.ID != id)
            {
                return BadRequest("Service cannot be null or ID mismatch.");
            }
            try
            {
                var updatedService = await _serviceService.UpdateServiceAsync(service);
                if (updatedService == null)
                {
                    return NotFound();
                }
                return Ok(updatedService);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the service.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            try
            {
                var service = await _serviceService.GetServiceByIdAsync(id);
                if (service == null)
                {
                    return NotFound();
                }
                await _serviceService.DeleteServiceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the service.");
            }
        }
    }
}
