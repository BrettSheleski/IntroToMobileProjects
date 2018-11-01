using System;
namespace FamilyList.iOS
{
    public class DbPathProviderForIOS : IDbPathProvider
    {
        public string GetDbPath()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string dbFileName = "myFamilyIOS.db3";

            string dbFullPath = System.IO.Path.Combine(directoryPath, dbFileName);

            return dbFullPath;
        }
    }
}
