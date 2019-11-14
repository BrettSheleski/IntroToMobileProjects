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

    }
}
