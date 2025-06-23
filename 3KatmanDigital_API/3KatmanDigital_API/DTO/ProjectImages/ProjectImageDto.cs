namespace _3KatmanDigital_API.DTO.ProjectImages
{
    public class ProjectImageDto
    {
        public Guid ID { get; set; }
        public string ImagePath { get; set; }
        public Guid ProjectID { get; set; }
    }
}