using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hesabım.Entities;
namespace Hesabım.Database.EntityFramework
{
    public class GiderDal : IBaseDal<Gider>
    {
        int ReturnValue;
        public List<Gider> GetAll()
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Giderler.ToList();
            }
        }
        public int Update(Gider gider)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var result = db.Giderler.Where(I => I.Id == gider.Id).FirstOrDefault();
                if (result != null)
                {
                    result.KategoriAdi = gider.KategoriAdi;
                    result.KayitTarihi = gider.KayitTarihi;
                    result.Tutar = gider.Tutar;
                    result.AltKategoriAdi = gider.AltKategoriAdi;
                    result.Aciklama = gider.Aciklama;
                    ReturnValue = db.SaveChanges();
                }
            }
            return ReturnValue;
        }

        public int Add(Gider Entity)
        {
            ReturnValue = 0;

            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                db.Giderler.Add(Entity);
                ReturnValue = db.SaveChanges();
            }
            return ReturnValue;
        }

        public int Delete(Gider gider)
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var Entity = db.Giderler.Where(I => I.Id == gider.Id).FirstOrDefault();
                if (Entity != null)
                {
                    db.Giderler.Remove(Entity);
                    ReturnValue = db.SaveChanges();
                }
            }
            return ReturnValue;
        }
    }
}
