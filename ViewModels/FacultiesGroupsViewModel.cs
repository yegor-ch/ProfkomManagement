using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.ViewModels
{
    public class FacultiesGroupsViewModel
    {
        public string FacultyTitle { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Member> MembersWithoutGroups { get; set; }
    }
}
