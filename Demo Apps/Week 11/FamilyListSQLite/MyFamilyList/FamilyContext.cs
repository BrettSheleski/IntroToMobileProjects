using System;
using Microsoft.EntityFrameworkCore;

namespace MyFamilyList
{
    public class FamilyContext : DbContext
    {
        public FamilyContext(DbContextOptions options) : base(options)
        {
        }

        

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>()
                .ToTable("person")
                .Property(p => p.FirstName)
                .HasColumnName("first_name");

        }
    }
}
