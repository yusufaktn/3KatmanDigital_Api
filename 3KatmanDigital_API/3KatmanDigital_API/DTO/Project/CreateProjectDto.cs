namespace _3KatmanDigital_API.DTO.Project
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
