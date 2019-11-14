using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFamilyList
{
    public class PersonRepository
    {

        public PersonRepository()
        {


            DbContextOptionsBuilder<FamilyContext> optionsBuilder = new DbContextOptionsBuilder<FamilyContext>();


            string dbFileName = "MyFamily.db";
            string dbDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFilePath = System.IO.Path.Combine(dbDirectoryPath, dbFileName);


            string connectionString = $"Data Source={dbFilePath}";


            optionsBuilder.UseSqlite(connectionString);


            DbContextOptions<FamilyContext> options = optionsBuilder.Options;
            


            Context = new FamilyContext(options);

            Context.Database.EnsureCreated();
        }

        public FamilyContext Context { get; }

        public void SaveNewPerson(Person p)
        {

            Context.People.Add(p);



            Context.SaveChanges();
        }

        public List<Person> GetAllPeople()
        {
            List<Person> allPeople = new List<Person>(Context.People);

            return allPeople;
        }
        
    }
}
