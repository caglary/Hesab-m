using System.Collections.Generic;
namespace Hesabım.Interface
{
    public interface IManagerBase<T>
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        List<T> List();
    }
}
