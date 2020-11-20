using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesabım.Database.SQLiteDAL
{
    public class Database
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        public Database()
        {
            connection = new SQLiteConnection("Data Source=Hesap.sqlite;Version=3;");
        }

        public void DatabaseExist()
        {
            if (!File.Exists("Hesap.sqlite"))
                DatabaseCreate();
        }
        public static string ConnectionString()
        {
            return "Data Source=Hesap.sqlite;Version=3;";
        }

        void DatabaseCreate()
        {
            SQLiteConnection.CreateFile("Hesap.sqlite");
            string createGelirQuery = CreateTableGelir();
            string createGiderQuery = CreateTableGider();
            string createKategoriQuery = CreateTableKategori();
            string createAltKategoriQuery = CreateTableAltKategori();

            connection.Open();
            command= new SQLiteCommand(createGelirQuery, connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand(createGiderQuery, connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand(createKategoriQuery, connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand(createAltKategoriQuery, connection);

            command.ExecuteNonQuery();

            connection.Close();


        }

        private string CreateTableGelir()
        {
            return "CREATE TABLE IF NOT EXISTS Gelir (" +
                "GelirId INTEGER PRIMARY KEY AUTOINCREMENT," +
                "Kategori    TEXT NOT NULL," +
                "AltKategori TEXT NOT NULL DEFAULT ''," +
                "Tutar   REAL NOT NULL," +
                "Aciklama TEXT NOT NULL," +
                "OlusturmaTarihi TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP)";
        }
        private string CreateTableGider()
        {
            return "CREATE TABLE IF NOT EXISTS Gider (" +
                "GiderId INTEGER PRIMARY KEY AUTOINCREMENT," +
                "Kategori    TEXT NOT NULL," +
                "AltKategori TEXT NOT NULL DEFAULT ''," +
                "Tutar   REAL NOT NULL," +
                "Aciklama TEXT NOT NULL," +
                "OlusturmaTarihi TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP)";
        }
        private string CreateTableKategori()
        {
            return "CREATE TABLE IF NOT EXISTS Kategori (" +
                "KategoriId INTEGER PRIMARY KEY AUTOINCREMENT," +
                "KategoriAdi    TEXT NOT NULL," +
                "OlusturmaTarihi TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP)";
        }
        private string CreateTableAltKategori()
        {
            return "CREATE TABLE IF NOT EXISTS AltKategori (" +
                "AltKategoriId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "AltKategoriAdi TEXT NOT NULL UNIQUE," +
                "KategoriId INTEGER NOT NULL," +
                "FOREIGN KEY(KategoriId)" +
                "REFERENCES Kategori(KategoriId) " +
                "ON DELETE CASCADE ON " +
                "UPDATE NO ACTION )";
        }

       

    }
}
