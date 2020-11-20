using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hesabım.Entities;
namespace Hesabım.Database.EntityFramework
{
    public class AltKategoriDal:IBaseDal<AltKategori>
    {
        int ReturnValue;
        public List<AltKategori> GetAll()
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.AltKategoriler.ToList();
            }
        }
        public int Add(AltKategori newAltKategori)
        {
            try
            {
                using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
                {
                    db.AltKategoriler.Add(newAltKategori);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {
               
                throw new Exception("Aynı isimde kayıt mevcut");
            }
           
        }
        public int Delete(AltKategori selectedAltKategori)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var entity = db.AltKategoriler.Where(I => I.Id == selectedAltKategori.Id).FirstOrDefault();
                if (entity!=null)
                {
                    db.AltKategoriler.Remove(entity);
                    ReturnValue= db.SaveChanges();
                }
            }
            return ReturnValue;
        }
        public int Update(AltKategori updatedAltKategori)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                var entity = db.AltKategoriler.Where(I => I.Id == updatedAltKategori.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.SubKategoriAdi = updatedAltKategori.SubKategoriAdi;
                    ReturnValue = db.SaveChanges();
                }
            }
            return ReturnValue;
        }

    }

   
}
