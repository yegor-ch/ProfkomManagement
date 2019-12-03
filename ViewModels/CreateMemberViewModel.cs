using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.ViewModels
{
    public class CreateMemberViewModel
    {
        [Required(ErrorMessage = "Поле Прізвище обов'язкове")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public bool IsScholarship { get; set; }
        [Required]
        public DateTime DateOfEntry { get; set; }
        public DateTime? DateOfExit { get; set; }
        public string NumberOfTicket { get; set; }
        public float Contribution { get; set; }
        public int? GroupId { get; set; }
        public int? FacultyId { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
    }
}
