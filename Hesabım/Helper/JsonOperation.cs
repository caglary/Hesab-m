using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hesabım.Entities;
namespace Hesabım.Helper
{
    static class JsonOperation
    {
        public static string ToJson<T>(List<T> parametre)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(parametre);
        }
        public static List<T> ToList<T>(string parametre)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(parametre);
        }
    }
}
