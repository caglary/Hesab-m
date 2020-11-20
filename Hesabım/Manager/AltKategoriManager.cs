using Hesabım.Database;
using Hesabım.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Manager
{
    public class AltKategoriManager
    {
        IBaseDal<AltKategori> _altKategoriDal;
        int ReturnValue;
        public AltKategoriManager()
        {
            _altKategoriDal = new Database.SQLiteDAL.AltKategoriSQLiteDal();
        }
        internal List<AltKategori> GetAll()
        {
            return _altKategoriDal.GetAll();
        }
        internal void Add(AltKategori newAltKategori)
        {
            ReturnValue = 0;
            try
            {
                ReturnValue = _altKategoriDal.Add(newAltKategori);
                if (ReturnValue > 0)
                {
                    Helper.Message.Information("Kaydınız eklendi.");
                }
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
           
        }
        internal List<AltKategori> GetAllByKategoriId(int kategoriId)
        {
            return GetAll().Where(I=>I.KategoriId==kategoriId).ToList();
        }
        internal void Delete(AltKategori selectedAltKategori)
        {
            ReturnValue = 0;
            try
            {
                ReturnValue = _altKategoriDal.Delete(selectedAltKategori);
                if (ReturnValue > 0)
                {
                    Helper.Message.Information("Kaydınız silindi.");
                }
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
        }
        internal void Update(AltKategori updatedAltKategori)
        {
            ReturnValue = 0;
            try
            {
                ReturnValue = _altKategoriDal.Update(updatedAltKategori);
                if (ReturnValue > 0)
                {
                    Helper.Message.Information("Kaydınız güncellendi.");
                }
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
            }
        }
    }
}
