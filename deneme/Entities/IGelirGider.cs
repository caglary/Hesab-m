using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Entities
{
    public interface IGelirGider
    {
        int ID { get; set; }
        DateTime Tarih { get; set; }
        string KategoriAdi { get; set; }
        string AltKategoriAdi { get; set; }
        decimal Tutar { get; set; }
        string Aciklama { get; set; }
    }
}
