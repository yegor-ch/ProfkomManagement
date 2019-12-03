using Microsoft.EntityFrameworkCore;
using ProfkomManagement.Data.Interfeces;
using ProfkomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Data.Repositories
{
    public class DbFacultiesRepository : IFacultyRepository
    {
        private readonly ProfkomDbContext _context;

        public DbFacultiesRepository(ProfkomDbContext context)
        {
            _context = context;
        }

        public Faculty Create(Faculty item)
        {
            _context.Faculties.Add(item);
            _context.SaveChanges();

            return item;
        }

        public Faculty Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Faculty Get(int id)
        {
            return _context.Faculties.Find(id);
        }

        public IEnumerable<Group> Groups(int id)
        {
            // Explicit loading groups of Faculty.

            var faculty = _context.Faculties.Where(f => f.Id == id).FirstOrDefault();
            _context.Entry(faculty).Collection(f => f.Groups).Load();

            //var groups = (from f in _context.Groups
            //              where f.FacultyId == id
            //              select f).ToList();

            return faculty.Groups;
        }
       

        public IEnumerable<Member> Members(int id)
        {
            var faculty = _context.Faculties.Where(f => f.Id == id).FirstOrDefault();
            _context.Entry(faculty).Collection(f => f.Members).Load();

            return faculty.Members;
        }

        public IEnumerable<Faculty> GetList()
        {
            return _context.Faculties;
        }

        public Faculty Update(Faculty itemChanges)
        {
            throw new NotImplementedException();
        }
    }
}
