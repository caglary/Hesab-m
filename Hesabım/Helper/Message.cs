using System;
using System.Windows.Forms;
namespace Hesabım.Helper
{
    public static class Message
    {
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal static DialogResult Information(string v)
        {
          return MessageBox.Show(v, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        internal static DialogResult Question(string v)
        {
            return MessageBox.Show(v, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
