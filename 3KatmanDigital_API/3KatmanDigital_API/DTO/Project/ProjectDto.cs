using _3KatmanDigital_API.DTO.ProjectImages;
using Entitiy.Models;
using System.Text.Json.Serialization;

namespace _3KatmanDigital_API.DTO.Project
{
    public class ProjectDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
       public List<ProjectImageDto>? Images { get; set; }
        




    }
}
