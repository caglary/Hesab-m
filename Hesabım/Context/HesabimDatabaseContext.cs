using Hesabım.Entities;
using Hesabım.Entities.FluentMap;
using System.Data.Entity;
namespace Hesabım.Context
{
    class HesabimDatabaseContext : DbContext
    {
        public HesabimDatabaseContext() : base("HesabimDB")
        {
        }
        public DbSet<Gelir> Gelirler { get; set; }
        public DbSet<Gider>  Giderler { get; set; }
        public DbSet<Kategori>  Kategoriler { get; set; }
        public DbSet<AltKategori>  AltKategoriler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GelirMap());
            modelBuilder.Configurations.Add(new GiderMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new AltKategoriMap());
        }
    }
}
