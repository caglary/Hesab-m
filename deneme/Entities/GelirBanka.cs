using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Entities
{
    public class GelirBanka:IGelirGider
    {
        public int ID { get; set; }
        public DateTime Tarih { get; set; }
        public string KategoriAdi { get; set; }
        public string AltKategoriAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

    }
}
