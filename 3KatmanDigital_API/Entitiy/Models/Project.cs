using System.Text.Json.Serialization;

namespace Entitiy.Models
{
    public class Project:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        [JsonIgnore]
        public ICollection<ProjectImages> Images { get; set; }

    }
}
