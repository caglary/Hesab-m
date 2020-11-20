using Hesabım.Forms;
using System;
using System.Windows.Forms;
using MainMenu = Hesabım.Forms.MainMenu;
namespace Hesabım
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
