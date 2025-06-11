using Entitiy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entitiy.Models
{
    public class ProjectRequest:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Message { get; set; }
        public Guid CategoryID { get; set; }

        [JsonIgnore]
        public Category Category{ get; set; }



    }
}
