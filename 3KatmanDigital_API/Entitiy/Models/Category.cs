using Entitiy.Models;
using System.Text.Json.Serialization;

namespace Entitiy.Models
{
    public class Category:BaseEntity
    {

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }

        [JsonIgnore]
        public  ICollection<ProjectRequest>  ProjectRequests{ get; set; }


    }
}
