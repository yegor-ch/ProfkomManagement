using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        public string Surname { get; set; }

        public string Name { get; set; }
        public string Patronymic { get; set; }
        public bool IsScholarship { get; set; }
       
        [Column(TypeName = "date")]
        public DateTime DateOfEntry { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfExit { get; set; }
        public string NumberOfTicket { get; set; }
        public float Contribution { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}

