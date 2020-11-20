using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabım.Database.SQLiteDAL
{
    public class GiderSQLiteDal : IBaseDal<Gider>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public GiderSQLiteDal()
        {
            Database db = new Database();
            db.DatabaseExist();
            connection = new SQLiteConnection(Database.ConnectionString());
        }
        public int Add(Gider Entity)
        {
            string query = "INSERT INTO Gider (Kategori,AltKategori,Tutar,Aciklama,OlusturmaTarihi) VALUES (@Kategori,@AltKategori,@Tutar,@Aciklama,@OlusturmaTarihi)";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Kategori", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@AltKategori", Entity.AltKategoriAdi);
            command.Parameters.AddWithValue("@Tutar", Entity.Tutar);
            command.Parameters.AddWithValue("@Aciklama", Entity.Aciklama);
            command.Parameters.AddWithValue("@OlusturmaTarihi", Entity.KayitTarihi);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public int Delete(Gider Entity)
        {
            string query = "delete from Gider where GiderId=@GiderId";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@GiderId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public List<Gider> GetAll()
        {
            List<Gider> liste = new List<Gider>();
            string query = "select * from Gider";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Gider _gider = new Gider();
                _gider.Id = reader.GetInt32(0);
                _gider.KategoriAdi = reader.GetString(1);
                _gider.AltKategoriAdi = reader.GetString(2);
                _gider.Tutar = reader.GetDecimal(3);
                _gider.Aciklama = reader.GetString(4);
                _gider.KayitTarihi = reader.GetDateTime(5);
                liste.Add(_gider);
            }
            reader.Close();
            connection.Close();
            return liste;
        }

        public int Update(Gider Entity)
        {
            string query = "update Gider " +
            "set Kategori=@Kategori," +
            "AltKategori=@AltKategori," +
            "Tutar=@Tutar," +
            "Aciklama=@Aciklama," +
            "OlusturmaTarihi=@OlusturmaTarihi " +
            "where GiderId=@GiderId ";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Kategori", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@AltKategori", Entity.AltKategoriAdi);
            command.Parameters.AddWithValue("@Tutar", Entity.Tutar);
            command.Parameters.AddWithValue("@Aciklama", Entity.Aciklama);
            command.Parameters.AddWithValue("@OlusturmaTarihi", Entity.KayitTarihi);
            command.Parameters.AddWithValue("@GiderId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }
    }
}
