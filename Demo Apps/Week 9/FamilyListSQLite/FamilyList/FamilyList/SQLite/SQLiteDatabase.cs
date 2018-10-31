using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace FamilyList.SQLite
{
    public class SQLiteDatabase
    {
        SQLiteConnection connection;

        public SQLiteDatabase(){

            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var dbPath = Path.Combine(folderPath, "mydb.db3");

            this.connection = new SQLiteConnection(dbPath);

            // make sure we have a table that can store FamilyMembers
            connection.CreateTable<FamilyMember>();
        }

        private static readonly object dbLock = new object();

        public void InsertFamilyMember(FamilyMember familyMember){

            lock(dbLock){
                connection.Insert(familyMember);
            }

        }

        public List<FamilyMember> GetAllFamilyMembers(){
            lock(dbLock){
                return connection.Table<FamilyMember>().ToList();
            }
        }
    }
}
