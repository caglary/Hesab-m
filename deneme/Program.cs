using deneme.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            using (context c = new context())
            {
                if (!c.Database.Exists())
                {
                    try
                    {
                        Console.WriteLine("Database oluşturuluyor....");
                        c.Database.Create();
                        Console.WriteLine("Database Oluşturma işlemi BİTTİ...");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("HATA OLUŞTU.");

                    }
                }
            }
            Console.WriteLine("Çıkış için bir tuşa basınız.");
            Console.ReadLine();

        }
    }
}
