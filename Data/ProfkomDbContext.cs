using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfkomManagement.Models;

namespace ProfkomManagement.Data
{
    public class ProfkomDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public ProfkomDbContext(DbContextOptions options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // When faculty or group will dalete, students wil be exist in table.
            modelBuilder.Entity<Group>().HasMany(m => m.Members).WithOne(g => g.Group).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Faculty>().HasMany(m => m.Members).WithOne(f => f.Faculty).OnDelete(DeleteBehavior.SetNull);

            //foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    rel.DeleteBehavior = DeleteBehavior.SetNull;
            //}
        }


    }
}
