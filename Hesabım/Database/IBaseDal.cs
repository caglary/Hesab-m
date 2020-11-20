using System.Collections.Generic;

namespace Hesabım.Database
{
    public interface IBaseDal<T>
    {
        List<T> GetAll();
        int Add(T Entity);
        int Delete(T Entity);
        int Update(T Entity);


    }
}