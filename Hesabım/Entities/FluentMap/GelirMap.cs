using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Entities.FluentMap
{
    public class GelirMap:EntityTypeConfiguration<Gelir>
    {
        public GelirMap()
        {
            this.ToTable("Gelirler");
            this.HasKey(I => I.Id);
            this.Property(I => I.Id)
                .HasColumnName("No")
                .HasColumnOrder(0)
                .HasColumnType("int");
            this.Property(I => I.KategoriAdi)
                .HasColumnName("Kategori")
                .HasColumnOrder(1)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(I => I.AltKategoriAdi)
               .HasColumnName("Alt Kategori")
               .HasColumnOrder(2)
               .HasColumnType("nvarchar")
               .IsRequired()
               .HasMaxLength(50);
            this.Property(I => I.Tutar)
               .HasColumnName("Tutar")
               .HasColumnOrder(3)
               .HasColumnType("decimal")
               .IsRequired();
            this.Property(I => I.KayitTarihi)
               .HasColumnName("Tarih")
               .HasColumnOrder(4)
               .HasColumnType("datetime")
               .IsRequired();
            this.Property(I => I.Aciklama)
               .HasColumnName("Açıklama")
               .HasColumnOrder(5)
               .HasColumnType("nvarchar")
               .IsRequired()
               .HasMaxLength(500);
        }
    }
}
