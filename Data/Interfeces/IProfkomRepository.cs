using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Models
{
    public interface IProfkomRepository
    {
        Member CreateMember(Member member);
        Member UpdateMember(Member memberChanges);
        Member DeleteMember(Member member);
        Member GetMember(int id);
        IEnumerable<Member> GetAllMembers();
        Group GetGroup(int id);
        IEnumerable<Group> GetGroups();
        Faculty GetFaculty(int id);
        IEnumerable<Faculty> GetFaculties();
    }
}
