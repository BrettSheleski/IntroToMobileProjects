using System;
namespace MyFamilyList
{
    public class Person
    {


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
