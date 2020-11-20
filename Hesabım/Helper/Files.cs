using System.IO;
using System.Windows.Forms;

namespace Hesabım.Helper
{
    public static class Files
    {
        public static void WriteAllText(string contents,string path)
        {
            File.WriteAllText(path, contents);
        }

        public static string FolderPath()
        {

            FolderBrowserDialog _folder = new FolderBrowserDialog();
            DialogResult result = _folder.ShowDialog();
            string _folderPath = string.Empty;
            if (result == DialogResult.OK)
            {
                _folderPath = _folder.SelectedPath;
            }
            return _folderPath;
        }
        public static string FilePath()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            return opf.FileName;
        }
    }
}
