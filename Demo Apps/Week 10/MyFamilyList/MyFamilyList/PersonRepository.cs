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

            App.Instance.Properties["FamilyMembers"] = json;

        }

        public List<Person> GetAllPeople()
        {
            if (App.Instance.Properties.ContainsKey("FamilyMembers"))
            {
                string json = (string)App.Instance.Properties["FamilyMembers"];

                if (!string.IsNullOrWhiteSpace(json))
                {
                    List<Person> people =
                        Newtonsoft.Json.JsonConvert.DeserializeObject< List<Person> >(json);

                    return people;
                }
            }

            return new List<Person>();
        }
        


    }
}
