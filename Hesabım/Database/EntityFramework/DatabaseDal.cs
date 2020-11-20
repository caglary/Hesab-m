using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hesabım.Context;
namespace Hesabım.Database.EntityFramework
{
    public class DatabaseDal
    {
        public void CreateDatabase()
        {
            using (HesabimDatabaseContext database = new HesabimDatabaseContext())
            {
               
                    database.Database.Create();
               
            }
        }
        internal void deleteDatabase()
        {
            using (HesabimDatabaseContext database = new HesabimDatabaseContext())
            {
                database.Database.Delete();
            }
        }
        public string ConnectionStringInfo()
        {
            using (Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Database.Connection.ConnectionString;
            }
        }
        public string ConnectionDataSource()
        {
            using (Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Database.Connection.DataSource;
            }
        }
        public string ConnectionDatabaseName()
        {
            using (Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Database.Connection.Database;
            }
        }
    }
}
