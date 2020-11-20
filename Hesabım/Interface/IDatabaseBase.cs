using System.Collections.Generic;
namespace Hesabım.Database.Interface
{
    public interface IDatabaseBase<T>
    {
        int ReturnValue { get;  set; } 
        int Add(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
        List<T> List();
    }
}
