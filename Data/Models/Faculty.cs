using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProfkomManagement.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Group> Groups { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Member> Members { get; set; }
    }
}