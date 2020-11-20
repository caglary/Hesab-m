namespace deneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bankas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BankaAdi = c.String(),
                        HesapAdi = c.String(),
                        HesapTürü = c.String(),
                        HesapNumarasi = c.String(),
                        IBAN = c.String(),
                        Bakiye = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GelirBankas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        KategoriAdi = c.String(),
                        AltKategoriAdi = c.String(),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aciklama = c.String(),
                        Banka_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bankas", t => t.Banka_ID)
                .Index(t => t.Banka_ID);
            
            CreateTable(
                "dbo.GiderBankas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        KategoriAdi = c.String(),
                        AltKategoriAdi = c.String(),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aciklama = c.String(),
                        Banka_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bankas", t => t.Banka_ID)
                .Index(t => t.Banka_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiderBankas", "Banka_ID", "dbo.Bankas");
            DropForeignKey("dbo.GelirBankas", "Banka_ID", "dbo.Bankas");
            DropIndex("dbo.GiderBankas", new[] { "Banka_ID" });
            DropIndex("dbo.GelirBankas", new[] { "Banka_ID" });
            DropTable("dbo.GiderBankas");
            DropTable("dbo.GelirBankas");
            DropTable("dbo.Bankas");
        }
    }
}
