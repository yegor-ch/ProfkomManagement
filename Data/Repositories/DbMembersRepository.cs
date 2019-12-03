using Microsoft.EntityFrameworkCore;
using ProfkomManagement.Data.Interfeces;
using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Data.Repositories
{
    public class DbMembersRepository : IMemberRepository
    {
        private readonly ProfkomDbContext _context;

        public DbMembersRepository(ProfkomDbContext context)
        {
            _context = context;       
        }

        public Member Create(Member item)
        {
           _context.Members.Add(item);
            _context.SaveChanges();

            return item;
        }

        public Member Delete(int id)
        {
            var member = _context.Members.Find(id);
            if(member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }

            return member;
        }

        public Member Get(int id)
        {
            return _context.Members.Find(id);
        }

        public IEnumerable<Member> GetList()
        {
            return _context.Members;
        }

        public Member Update(Member itemChanges)
        {
            var member = _context.Members.Attach(itemChanges);
            //member.State = EntityState.Modified;
            _context.SaveChanges();

            return null;
        }

        public IEnumerable<Member> Search(string search)
        {
            var members = from m in _context.Members
                          select m;

            if(!string.IsNullOrEmpty(search))
            {              
                members = members.Where(m => m.Surname.Contains(search));
            }

            return members.ToList();
        }


    }
}
