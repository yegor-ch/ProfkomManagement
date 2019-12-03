using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Data.Interfeces
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        IEnumerable<Member> Members(int id);
        IEnumerable<Group> Groups(int id);
    }
}
