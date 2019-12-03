using Microsoft.EntityFrameworkCore;
using ProfkomManagement.Data.Interfeces;
using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Data.Repositories
{
    public class DbGroupRepository : IGroupRepository
    {
        private readonly ProfkomDbContext _context;

        public DbGroupRepository(ProfkomDbContext context)
        {
            _context = context;          
        }
        public Group Create(Group item)
        {
            _context.Groups.Add(item);
            _context.SaveChanges();
            
            return item;
        }

        public Group Delete(int id)
        {
            var groupToDelete = _context.Groups.Find(id);

            if(groupToDelete != null)
            {
               
                _context.Groups.Remove(groupToDelete);
                _context.SaveChanges();
            }

            return groupToDelete;
        }

        public Group Get(int id)
        {
            return _context.Groups.Find(id);
        }

        // Check this method.
        public IEnumerable<Member> GetGroupMembers(int id)
        {
            var group = _context.Groups.Where(g => g.Id == id).FirstOrDefault();
            _context.Entry(group).Collection(g => g.Members).Load();

            return group.Members;
        }

        public IEnumerable<Group> GetList()
        {
            return _context.Groups;
        }

        public Group Update(Group itemChanges)
        {
            throw new NotImplementedException();
        }
    }
}
