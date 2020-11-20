using System;
using System.Windows.Forms;
using Hesabım.Entities;
namespace Hesabım.Forms
{
    public partial class AddAltKategori : Form
    {
        AltKategori _altKategori;
        Kategori _kategori;
        Manager.AltKategoriManager _altKategoriManager;
        public AddAltKategori(AltKategori AltKategori, Kategori kategori)
        {
            InitializeComponent();
            _altKategori = AltKategori;
            _kategori = kategori;
            _altKategoriManager = new Manager.AltKategoriManager();
        }
        private void AddAltKategori_Load(object sender, EventArgs e)
        {
            try
            {
                txtAltKategoriAdi.Focus();
                if (_altKategori == null)
                {
                    _altKategori = new AltKategori { Id = 0, SubKategoriAdi = "Kayıt yok" };
                }
                txtAltKategoriAdi.Text = _altKategori.SubKategoriAdi;
                listBoxAltKategori.DataSource = _altKategoriManager.GetAllByKategoriId(_kategori.Id);
                listBoxAltKategori.DisplayMember = "SubKategoriAdi";
            }
            catch (NullReferenceException _nullReferenceException)
            {
                MessageBox.Show(_nullReferenceException.Message);
            }

        }
        private void listBoxAltKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedObject = listBoxAltKategori.SelectedItem;
            AltKategori selectedAltKategori = (AltKategori)selectedObject;
            txtAltKategoriAdi.Text = selectedAltKategori.SubKategoriAdi;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AltKategori newAltKategori = new AltKategori { SubKategoriAdi = txtAltKategoriAdi.Text, KategoriId = _kategori.Id };
            _altKategoriManager.Add(newAltKategori);
            listBoxAltKategori.DataSource = _altKategoriManager.GetAllByKategoriId(_kategori.Id);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            object selectedObject = listBoxAltKategori.SelectedItem;
            AltKategori selectedAltKategori = (AltKategori)selectedObject;
            if (selectedAltKategori != null)
            {
                AltKategori updatedAltKategori = new AltKategori { Id = selectedAltKategori.Id, SubKategoriAdi = txtAltKategoriAdi.Text };
                _altKategoriManager.Update(updatedAltKategori);
                listBoxAltKategori.DataSource = _altKategoriManager.GetAllByKategoriId(_kategori.Id);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainmanuform = Application.OpenForms["MainMenu"];
            Panel panel2 = (Panel)mainmanuform.Controls["panel2"];
            ComboBox cmbAltKategori = (ComboBox)panel2.Controls["cmbAltKategori"];
            cmbAltKategori.DataSource = _altKategoriManager.GetAllByKategoriId(_kategori.Id);
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            object selectedObject = listBoxAltKategori.SelectedItem;
            AltKategori selectedAltKategori = (AltKategori)selectedObject;
            if (selectedAltKategori != null)
            {
                _altKategoriManager.Delete(selectedAltKategori);
                listBoxAltKategori.DataSource = _altKategoriManager.GetAllByKategoriId(_kategori.Id);
            }
        }
    }
}
