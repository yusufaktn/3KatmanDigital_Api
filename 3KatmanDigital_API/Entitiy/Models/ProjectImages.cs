using System.Text.Json.Serialization;

namespace Entitiy.Models
{
    public class ProjectImages:BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid ProjectID { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
    }
}
