using System;
namespace Hesabım.Entities
{
    public class Gelir : IGelirGiderBase
    {
        public int Id { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string KategoriAdi { get; set; }
        public string AltKategoriAdi { get; set; }

        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
       

    }
}
