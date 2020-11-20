using deneme.Entities;
using System.Data.Entity;

namespace deneme.Entities
{
    public class context:DbContext
    {
        public context():base(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=deneme;Integrated Security=True")
        {

        }
        public DbSet<Banka> Banka { get; set; }
        public DbSet<GelirBanka> Gelirler { get; set; }
        public DbSet<GiderBanka> Giderler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banka>().ToTable("Bankalar", "Hesap");
            modelBuilder.Entity<GelirBanka>().ToTable("BankaGelirler", "Hesap");
            modelBuilder.Entity<GiderBanka>().ToTable("BankaGiderler", "Hesap");

        }

    }
}
