using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Entities.FluentMap
{
    public class KategoriMap:EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            this.ToTable("Kategoriler");
            this.HasKey(I => I.Id);
            this.HasIndex(I => I.KategoriAdi).IsUnique();
            this.Property(I => I.Id)
                .HasColumnOrder(0)
                .HasColumnName("No")
                .HasColumnType("int");
            this.Property(I => I.KategoriAdi)
                .HasColumnName("Kategori")
                .HasColumnOrder(1)
                .HasColumnType("nvarchar");
                
        }
    }
}
