namespace Hesabım.Entities
{
    public class AltKategori : IAltKategori
    {
        public int Id { get; set; }
        public string SubKategoriAdi { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
