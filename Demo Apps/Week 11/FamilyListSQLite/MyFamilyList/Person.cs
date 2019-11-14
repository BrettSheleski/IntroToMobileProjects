using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFamilyList
{
    public class Person
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime BirthDate { get; set; }


        public string DisplayName
        {
            get
            {
                //return FirstName + " " + LastName;
                //return string.Format("{0} {1}", FirstName, LastName);
                return $"{FirstName} {LastName}";
            }
        }
    }
}
