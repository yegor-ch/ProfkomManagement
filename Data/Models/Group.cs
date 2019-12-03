using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfkomManagement.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? FacultyId { get; set; }

        //[JsonIgnore]
        public virtual Faculty Faculty { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Member> Members { get; set; }
    }
}