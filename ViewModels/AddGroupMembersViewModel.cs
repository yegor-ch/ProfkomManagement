using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.ViewModels
{
    public class AddGroupMembersViewModel
    {
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public string FacultyTitle { get; set; }
        public IEnumerable<Member> MembersWithGroup { get; set; }
        public IEnumerable<Member> MembersWithoutGroup { get; set; }

    }
}
