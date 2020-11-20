using Hesabım.Database;
using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Hesabım.Manager
{
    public class GiderManager
    {
        IBaseDal<Gider> giderDal;
        int ReturnValue;
        public GiderManager()
        {
            giderDal = new Database.SQLiteDAL.GiderSQLiteDal();
        }
        internal List<Gider> GetAll()
        {
            return giderDal.GetAll();
        }
        internal string Toplam()
        {
            try
            {
                var ReturnToplam =GetAll().Sum(I => I.Tutar);
                return ReturnToplam.ToString();
            }
            catch (System.InvalidOperationException exception)
            {
                return 0.ToString();
            }
        }
        internal void Add(string kategori, string altKategori, DateTime tarih, decimal tutar, string aciklama)
        {
            ReturnValue = 0;
            Gider _gider = new Gider();
            _gider.Aciklama = aciklama;
            _gider.AltKategoriAdi = altKategori;
            _gider.KategoriAdi = kategori;
            _gider.KayitTarihi = tarih;
            _gider.Tutar = tutar;
            ReturnValue = giderDal.Add(_gider);
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
            
            var _liste = giderDal.GetAll();
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
            Gider _gider = new Gider();
            _gider.Id = id;
            ReturnValue = giderDal.Delete(_gider);
            if (ReturnValue > 0)
            {
                Helper.Message.Information("Kayıt Silindi.");
            }
            else
            {
                Helper.Message.Error("Silme işleminiz başarısız.");
            }
        }
        internal void Update(string kategori, string altKategori, DateTime tarih, decimal tutar, string aciklama, int ıd)
        {
            Gider gider = new Gider();
            gider.Aciklama = aciklama;
            gider.AltKategoriAdi = altKategori;
            gider.Id = ıd;
            gider.KategoriAdi = kategori;
            gider.KayitTarihi = tarih;
            gider.Tutar = tutar;
            int ReturnValue = giderDal.Update(gider);
        }
        internal List<Entities.Gider> GetAll(DateTime baslangicTarih, DateTime bitisTarih)
        {
            var liste = GetAll();
            var yeniListe = from I in liste
                            where I.KayitTarihi >= baslangicTarih && I.KayitTarihi < bitisTarih
                            orderby I.KayitTarihi descending
                            select I;
            List<Entities.Gider> returnList = new List<Gider>();
            foreach (var item in yeniListe)
            {
                returnList.Add(item);
            }
            return returnList;
        }
    }
}
