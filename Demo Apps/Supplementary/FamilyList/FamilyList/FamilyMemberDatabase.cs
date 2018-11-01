using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyList
{
    public class FamilyMemberDatabase
    {

        SQLite.SQLiteConnection dbConnection;

        public FamilyMemberDatabase()
        {
            IDbPathProvider pathProvider = Xamarin.Forms.DependencyService.Get<IDbPathProvider>();

            string dbFullPath = pathProvider.GetDbPath();

            dbConnection = new SQLite.SQLiteConnection(dbFullPath);

            dbConnection.CreateTable<FamilyMember>();
        }


        public List<FamilyMember> GetAllFamilyMembers(){
            // SELECT * FROM [FamilyMembers]

            // get the results from above query

            // loop through the results and create a new FamilyMember instance for each row

            // add each FamilyMember instance to a list

            // return the list

            var tableQuery = dbConnection.Table<FamilyMember>();

            List<FamilyMember> familyMemberList = tableQuery.ToList();

            return familyMemberList;
        }

        public void InsertFamilyMember(FamilyMember theFamilyMember)
        {
            // INSERT INTO [FamilyMember] (FirstName, LastName, BirthDate) VALUES (x, y, z)

            // execute the above query

            dbConnection.Insert(theFamilyMember);
        }
    }
}
