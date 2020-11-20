using Hesabım.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabım.Database.SQLiteDAL
{
    public class GelirSQLiteDal : IBaseDal<Gelir>
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public GelirSQLiteDal()
        {
            Database db = new Database();
            db.DatabaseExist();
            connection = new SQLiteConnection(Database.ConnectionString());
        }
        public int Add(Gelir Entity)
        {
            string query = "INSERT INTO Gelir (Kategori,AltKategori,Tutar,Aciklama,OlusturmaTarihi) VALUES(@Kategori,@AltKategori,@Tutar,@Aciklama,@OlusturmaTarihi)";
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

        public int Delete(Gelir Entity)
        {
            string query = "delete from Gelir where GelirId=@GelirId";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@GelirId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;
        }

        public List<Gelir> GetAll()
        {
            List<Gelir> liste = new List<Gelir>();
            string query = "select * from Gelir";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Gelir _gelir = new Gelir();
                _gelir.Id = reader.GetInt32(0);
                _gelir.KategoriAdi = reader.GetString(1);
                _gelir.AltKategoriAdi = reader.GetString(2);
                _gelir.Tutar = reader.GetDecimal(3);
                _gelir.Aciklama = reader.GetString(4);
                _gelir.KayitTarihi = reader.GetDateTime(5);
                liste.Add(_gelir);
            }
            reader.Close();
            connection.Close();
            return liste;

        }

        public int Update(Gelir Entity)
        {
            string query = "update Gelir " +
                "set Kategori=@Kategori," +
                "AltKategori=@AltKategori," +
                "Tutar=@Tutar," +
                "Aciklama=@Aciklama," +
                "OlusturmaTarihi=@OlusturmaTarihi " +
                "where GelirId=@GelirId ";
            connection.Open();
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Kategori", Entity.KategoriAdi);
            command.Parameters.AddWithValue("@AltKategori", Entity.AltKategoriAdi);
            command.Parameters.AddWithValue("@Tutar", Entity.Tutar);
            command.Parameters.AddWithValue("@Aciklama", Entity.Aciklama);
            command.Parameters.AddWithValue("@OlusturmaTarihi", Entity.KayitTarihi);
            command.Parameters.AddWithValue("@GelirId", Entity.Id);
            command.Prepare();
            int Result = command.ExecuteNonQuery();
            connection.Close();
            return Result;

        }
    }
}
