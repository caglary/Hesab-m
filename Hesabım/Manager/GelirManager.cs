using Hesabım.Database;
using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Hesabım.Manager
{
    public class GelirManager
    {
        int ReturnValue;
        IBaseDal<Gelir> gelirDal;
        public GelirManager()
        {
            gelirDal = new Database.SQLiteDAL.GelirSQLiteDal();
        }
        internal List<Gelir> GetAll()
        {
            return gelirDal.GetAll();
        }
        internal void Add(string kategori, string altKategori, DateTime tarih, decimal tutar, string aciklama)
        {
            Gelir gelir = new Gelir();
            gelir.Aciklama = aciklama;
            gelir.AltKategoriAdi = altKategori;
            gelir.KategoriAdi = kategori;
            gelir.KayitTarihi = tarih;
            gelir.Tutar = tutar;
            ReturnValue = gelirDal.Add(gelir);
            if (ReturnValue > 0)
            {
                Helper.Message.Information("Kayıt Ekleme İşleminiz başarılı.");
            }
            else
            {
                Helper.Message.Error("Kayıt işleminiz başarısız.");
            }
        }
        internal string ToplamTutarByDate(DateTime firstdate, DateTime seconddate)
        {
            decimal tutar = 0;
            var _liste = gelirDal.GetAll();
            if (firstdate.Date != seconddate.Date)
            {
                var yeniListe = from g in _liste
                                where g.KayitTarihi.Date >= firstdate.Date && g.KayitTarihi.Date < seconddate.Date
                                select g;
                foreach (var item in yeniListe)
                {
                    tutar += item.Tutar;
                }
            }
            else
            {
                var yeniListe = from g in _liste
                                where g.KayitTarihi.Date == firstdate.Date
                                select g;
                foreach (var item in yeniListe)
                {
                    tutar += item.Tutar;
                }
            }
            return tutar.ToString();
        }
        internal void Delete(int id)
        {
            Gelir _gelir = new Gelir();
            _gelir.Id = id;
            ReturnValue = gelirDal.Delete(_gelir);
            if (ReturnValue > 0)
            {
                Helper.Message.Information("Kayıt Silindi.");
            }
            else
            {
                Helper.Message.Error("Silme işleminiz başarısız.");
            }
        }
        internal string Toplam()
        {
            try
            {
                return gelirDal.GetAll().Sum(I => I.Tutar).ToString();
            }
            catch (System.InvalidOperationException exception)
            {
                return 0.ToString();
            }
        }
        internal void Update(string kategori, string altKategori, DateTime tarih, decimal tutar, string aciklama, int ıd)
        {
            Gelir gelir = new Gelir();
            gelir.Aciklama = aciklama;
            gelir.AltKategoriAdi = altKategori;
            gelir.Id = ıd;
            gelir.KategoriAdi = kategori;
            gelir.KayitTarihi = tarih;
            gelir.Tutar = tutar;
            int ReturnValue = gelirDal.Update(gelir);
        }
        internal List<Entities.Gelir> GetAll(DateTime baslangicTarih, DateTime bitisTarih)
        {
            var liste = GetAll();
            var yeniListe = from I in liste
                            where I.KayitTarihi >= baslangicTarih && I.KayitTarihi < bitisTarih
                            orderby I.KayitTarihi descending
                            select I;
            List<Entities.Gelir> returnList = new List<Gelir>();
            foreach (var item in yeniListe)
            {
                returnList.Add(item);
            }
            return returnList;
        }
    }
}
