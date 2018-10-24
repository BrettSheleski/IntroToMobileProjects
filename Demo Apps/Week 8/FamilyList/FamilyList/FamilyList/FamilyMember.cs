using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyList
{
    public class FamilyMember 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public DateTime BirthDate { get; set; }
    }
}
