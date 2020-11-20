using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Database.EntityFramework
{
    public class GelirDal:IBaseDal<Gelir>
    {
        int ReturnValue;
        public List<Gelir> GetAll()
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Gelirler.ToList();
            }
        }
       
        public int Update(Gelir gelir)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var result = db.Gelirler.Where(I => I.Id == gelir.Id).FirstOrDefault();
                if (result != null)
                {
                    result.KategoriAdi = gelir.KategoriAdi;
                    result.KayitTarihi = gelir.KayitTarihi;
                    result.Tutar = gelir.Tutar;
                    result.AltKategoriAdi = gelir.AltKategoriAdi;
                    result.Aciklama = gelir.Aciklama;
                    ReturnValue = db.SaveChanges();
                }
            }
            return ReturnValue;
        }

        public int Add(Gelir Entity)
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                db.Gelirler.Add(Entity);
                ReturnValue = db.SaveChanges();
            }
            return ReturnValue;
        }

        public int Delete(Gelir Entity)
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var result = db.Gelirler.Where(I => I.Id == Entity.Id).FirstOrDefault();
                if (result != null)
                {
                    db.Gelirler.Remove(result);
                    ReturnValue = db.SaveChanges();
                }
            }
            return ReturnValue;
        }
    }
}
