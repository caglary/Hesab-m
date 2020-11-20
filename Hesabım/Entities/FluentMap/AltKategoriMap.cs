using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Entities.FluentMap
{
    public class AltKategoriMap:EntityTypeConfiguration<AltKategori>
    {
        public AltKategoriMap()
        {
            this.ToTable("Alt Kategoriler");
            this.HasIndex(I => I.SubKategoriAdi).IsUnique();
            this.HasKey(I => I.Id);
            this.Property(I => I.Id)
                .HasColumnOrder(0)
                .HasColumnName("No")
                .HasColumnType("int");
            this.Property(I => I.SubKategoriAdi)
               .HasColumnOrder(1)
               .HasColumnName("Alt Kategori")
               .HasColumnType("nvarchar")
               .IsRequired();
            this.Property(I => I.KategoriId)
             .HasColumnOrder(2)
             .HasColumnName("Kategori ID")
             .HasColumnType("int")
             .IsRequired();
        }
    }
}
