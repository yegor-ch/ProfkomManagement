using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.ViewModels
{
    public class CreateGroupViewModel
    {
        public string Title { get; set; }
        public int? FacultyId { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
    }
}
