namespace Hesabım.Entities
{
    public class Nakit
    {
        public int ID { get; set; }
        public decimal Bakiye { get; set; }
        public void BakiyeEkle(decimal Tutar) { Bakiye += Tutar; }
        public void BakiyeCıkar(decimal Tutar) { Bakiye -= Tutar; }
    }
}