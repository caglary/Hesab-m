using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hesabım.Entities;
namespace Hesabım.Database.EntityFramework
{
    public class KategoriDal:IBaseDal<Kategori>
    {
        int ReturnValue;
        public List<Kategori> GetAll()
        {
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                return db.Kategoriler.ToList();
            }
        }
        public int Add(Kategori newKategori)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                
                try
                {
                    db.Kategoriler.Add(newKategori);
                    ReturnValue = db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException )
                {
                    throw new Exception("Aynı isimde kayıt mevcuttur.");
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return ReturnValue;
        }
        public int Update(Kategori updatedKategori)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                try
                {
                    Entities.Kategori findedKategori = db.Kategoriler.Find(updatedKategori.Id);
                    if (findedKategori != null)
                    {
                        findedKategori.KategoriAdi = updatedKategori.KategoriAdi;
                    }
                    ReturnValue = db.SaveChanges();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return ReturnValue;
        }
        public int Delete(Kategori selectedKategori)
        {
            ReturnValue = 0;
            using (Hesabım.Context.HesabimDatabaseContext db = new Context.HesabimDatabaseContext())
            {
                try
                {
                    Entities.Kategori findedKategori = db.Kategoriler.Find(selectedKategori.Id);
                    if (findedKategori != null)
                    {
                        db.Kategoriler.Remove(findedKategori);
                        ReturnValue = db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Silmek istediğiniz kayıt database içerisinde bulunamadı.");
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return ReturnValue;
        }

      

    }
}
