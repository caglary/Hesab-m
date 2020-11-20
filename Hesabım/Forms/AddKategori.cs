using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hesabım.Forms
{
    public partial class AddKategori : Form
    {
        Entities.Kategori _kategori;
        Manager.KategoriManager _kategoriManager;
        public AddKategori(Entities.Kategori Kategori)
        {
            InitializeComponent();
            _kategori = Kategori;
            _kategoriManager = new Manager.KategoriManager();
        }
        private void Kategori_Load(object sender, EventArgs e)
        {
            txtKategoriAdi.Focus();
            if (_kategori == null)
            {
                _kategori = new Entities.Kategori { Id = 0, KategoriAdi = "Kayıt yok" };
            }
            txtKategoriAdi.Text = _kategori.KategoriAdi;
            listBoxKategori.DataSource = _kategoriManager.GetAll();
            listBoxKategori.DisplayMember = "KategoriAdi";
        }
        private void listBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedObject = listBoxKategori.SelectedItem;
            Entities.Kategori selectedKategori = (Entities.Kategori)selectedObject;
            txtKategoriAdi.Text = selectedKategori.KategoriAdi;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Entities.Kategori newKategori = new Entities.Kategori { KategoriAdi = txtKategoriAdi.Text };
            _kategoriManager.Add(newKategori);
            listBoxKategori.DataSource = _kategoriManager.GetAll();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            object selectedObject = listBoxKategori.SelectedItem;
            Entities.Kategori selectedKategori = (Entities.Kategori)selectedObject;
            if (selectedKategori != null)
            {
                Entities.Kategori updatedKategori = new Entities.Kategori { Id = selectedKategori.Id, KategoriAdi = txtKategoriAdi.Text };
                _kategoriManager.Update(updatedKategori);
                listBoxKategori.DataSource = _kategoriManager.GetAll();
            }
          
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainmanuform= Application.OpenForms["MainMenu"];
            Panel panel2 = (Panel)mainmanuform.Controls["panel2"];
            ComboBox cmbKategori = (ComboBox)panel2.Controls["cmbKategori"];
            cmbKategori.DataSource = _kategoriManager.GetAll();
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            object selectedObject = listBoxKategori.SelectedItem;
            Entities.Kategori selectedKategori = (Entities.Kategori)selectedObject;
            if (selectedKategori != null)
            {
               
                _kategoriManager.Delete(selectedKategori);
                listBoxKategori.DataSource = _kategoriManager.GetAll();
            }
        }
    }
    
}
