using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hesabım.Helper
{
    public static class Hata
    {
       public static void trycatch(Action metot)
        {
            string FilePath = "hata.txt";
            try
            {
                metot.Invoke();
            }
            catch (Exception exception)
            {
                Helper.Message.Error(exception.Message);
          
                Helper.Files.WriteAllText(exception.Message,FilePath );
            }
        }
       
    }
}
