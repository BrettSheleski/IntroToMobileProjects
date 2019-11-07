using System;
using System.Collections.Generic;

namespace MyFamilyList
{
    public class PersonRepository
    {



        public void SaveNewPerson(Person p)
        {
            var people = GetAllPeople();

            people.Add(p);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(people);

        }

        public List<Person> GetAllPeople()
        {
            return new List<Person>();
        }
        


    }
}
