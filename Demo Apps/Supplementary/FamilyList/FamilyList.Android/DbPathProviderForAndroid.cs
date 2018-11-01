using System;
namespace FamilyList.Droid
{
	public class DbPathProviderForAndroid : IDbPathProvider
    {
       
        public string GetDbPath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string dbFileName = "myFamilyAndroid.db3";

            string dbFullPath = System.IO.Path.Combine(directoryPath, dbFileName);

            return dbFullPath;
        }
    }
}
