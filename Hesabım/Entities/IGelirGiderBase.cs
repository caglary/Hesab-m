using System;

namespace Hesabım.Entities
{
    public interface IGelirGiderBase
    {
        string Aciklama { get; set; }
        string AltKategoriAdi { get; set; }
        int Id { get; set; }
        string KategoriAdi { get; set; }
        DateTime KayitTarihi { get; set; }
        decimal Tutar { get; set; }
    }
}