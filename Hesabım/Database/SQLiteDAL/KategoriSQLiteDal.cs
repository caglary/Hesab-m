using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabım.Database.SQLiteDAL
{
    public class KategoriSQLiteDal : IBaseDal<Kategori>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public KategoriSQLiteDal()
        {
            Database db = new Database();
            db.DatabaseExist();
            connection = new SQLiteConnection(Database.ConnectionString());
        }
        public int Add(Kategori Entity)
        {
            string query = "INSERT INTO Kategori (KategoriAdi,OlusturmaTarihi) VALUES (@KategoriAdi,@OlusturmaTarihi)";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@KategoriAdi", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now.ToShortDateString());
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public int Delete(Kategori Entity)
        {
            string query = "delete from Kategori where KategoriId=@KategoriId";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@KategoriId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public List<Kategori> GetAll()
        {
            List<Kategori> liste = new List<Kategori>();
            string query = "select * from Kategori";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Kategori _kategori = new Kategori();
                _kategori.Id = reader.GetInt32(0);
                _kategori.KategoriAdi = reader.GetString(1);
              
                liste.Add(_kategori);
            }
            reader.Close();
            connection.Close();
            return liste;
        }

        public int Update(Kategori Entity)
        {
            string query = "update Kategori " +
           "set KategoriAdi=@KategoriAdi, " +
           "OlusturmaTarihi=@OlusturmaTarihi where KategoriId=@KategoriId ";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@KategoriAdi", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@OlusturmaTarihi",DateTime.Now.ToShortDateString());
            command.Parameters.AddWithValue("@KategoriId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }
    }
}
