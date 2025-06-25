namespace _3KatmanDigital_API.DTO.ProjectImages
{
    public class UpdateProjectImageDto
    {
        public Guid ID { get; set; }
        public string ImagePath { get; set; }
        public Guid ProjectID { get; set; }
    }
}
