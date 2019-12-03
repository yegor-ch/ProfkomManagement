using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.ViewModels
{
    public class EditMemberViewModel : CreateMemberViewModel
    {
        public int Id { get; set; }
        public string GroupTitle { get; set; }
    }
}

