namespace Hesabım.Entities
{
    public interface IAltKategori
    {
        int Id { get; set; }
        Kategori Kategori { get; set; }
        int KategoriId { get; set; }
        string SubKategoriAdi { get; set; }
    }
}