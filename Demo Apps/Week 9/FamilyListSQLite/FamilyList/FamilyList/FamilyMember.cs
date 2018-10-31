using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FamilyList
{
    public class FamilyMember 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


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
