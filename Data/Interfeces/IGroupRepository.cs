using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Data.Interfeces
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Member> GetGroupMembers(int id);
    }
}
