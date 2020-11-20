using Hesabım.Database;
using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Manager
{
    public class KategoriManager
    {
        IBaseDal<Kategori> kategoriDal;
        int ReturnValue = 0;
        public KategoriManager()
        {
            kategoriDal = new Database.SQLiteDAL.KategoriSQLiteDal();
        }
        internal List<Kategori> GetAll()
        {
            return kategoriDal.GetAll();
        }
        internal void Add(Kategori newKategori)
        {
            try
            {
                ReturnValue = kategoriDal.Add(newKategori);
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
            if (ReturnValue>0)
            {
                Helper.Message.Information("Kayıt ekleme işlemi başarılı");
            }
        }
        internal void Update(Kategori updatedKategori)
        {
            try
            {
                ReturnValue = kategoriDal.Update(updatedKategori);
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
            if (ReturnValue > 0)
            {
                Helper.Message.Information("Güncelleme işlemi başarılı");
            }
        }
        internal void Delete(Kategori selectedKategori)
        {
            try
            {
                ReturnValue = kategoriDal.Delete(selectedKategori);
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
            if (ReturnValue > 0)
            {
                Helper.Message.Information("Silme işlemi başarılı");
            }
        }
    }
}
