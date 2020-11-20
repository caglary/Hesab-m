using System;
namespace Hesabım.Manager
{
    internal class DatabaseManager
    {
        Database.EntityFramework.DatabaseDal databaseDal;
        public DatabaseManager()
        {
            databaseDal = new Database.EntityFramework.DatabaseDal(); 
        }
        public  string ConnectionString()
        {
            return databaseDal.ConnectionStringInfo();
        }
        public string ConnectionDataSource()
        {
            return databaseDal.ConnectionDataSource();
        }
        public string ConnectionDatabaseName()
        {
            return databaseDal.ConnectionDatabaseName();
        }
    }
}