using Microsoft.AspNetCore.Http;

namespace _3KatmanDigital_API.DTO.Project
{
    public class UpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public List<IFormFile> Images { get; set; } 
    }
}
