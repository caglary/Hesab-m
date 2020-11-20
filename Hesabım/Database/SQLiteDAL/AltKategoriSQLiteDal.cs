using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabım.Database.SQLiteDAL
{
    public class AltKategoriSQLiteDal : IBaseDal<AltKategori>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public AltKategoriSQLiteDal()
        {
            Database db = new Database();
            db.DatabaseExist();
            connection = new SQLiteConnection(Database.ConnectionString());
        }
        public int Add(AltKategori Entity)
        {
            string query = "INSERT INTO AltKategori (AltKategoriAdi,KategoriId) VALUES (@AltKategoriAdi,@KategoriId)";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@AltKategoriAdi", Entity.SubKategoriAdi);
            command.Parameters.AddWithValue("@KategoriId", Entity.KategoriId);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public int Delete(AltKategori Entity)
        {
            string query = "delete from AltKategori where AltKategoriId=@AltKategoriId";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@AltKategoriId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public List<AltKategori> GetAll()
        {
            List<AltKategori> liste = new List<AltKategori>();
            string query = "select * from AltKategori";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AltKategori _altKategori = new AltKategori();
                _altKategori.Id = reader.GetInt32(0);
                _altKategori.SubKategoriAdi = reader.GetString(1);
                _altKategori.KategoriId = reader.GetInt32(2);

                liste.Add(_altKategori);
            }
            reader.Close();
            connection.Close();
            return liste;
        }

        public int Update(AltKategori Entity)
        {
            string query = "update AltKategori " +
          "set AltKategoriAdi=@AltKategoriAdi, " +
          "KategoriId=@KategoriId where AltKategoriId=@AltKategoriId ";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@AltKategoriAdi", Entity.SubKategoriAdi);
            command.Parameters.AddWithValue("@KategoriId",Entity.KategoriId);
            command.Parameters.AddWithValue("@AltKategoriId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }
    }
}
