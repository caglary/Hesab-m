namespace Hesabım.Entities
{
    public class Banka
    {
        public int ID { get; set; }
        public string HesapAdi { get; set; }
        public string HesapTürü { get; set; }
        public string HesapNumarasi { get; set; }
        public string IBAN { get; set; }
        public decimal Bakiye { get; set; }
        public void BakiyeEkle(decimal tutar) { Bakiye += tutar; }
        public void BakiyeCıkar(decimal tutar) { Bakiye -= tutar; }


    }

}