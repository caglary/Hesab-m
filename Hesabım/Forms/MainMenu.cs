using Hesabım.Manager;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hesabım.Entities;
using System.Linq;
namespace Hesabım.Forms
{
    public partial class MainMenu : Form
    {
        GelirManager gelirManager;
        GiderManager giderManager;
        KategoriManager kategoriManager;
        AltKategoriManager altKategoriManager;
        DatabaseManager databaseManager;
        public MainMenu()
        {
            InitializeComponent();
            gelirManager = new GelirManager();
            giderManager = new GiderManager();
            kategoriManager = new KategoriManager();
            altKategoriManager = new AltKategoriManager();
            databaseManager = new DatabaseManager();
        }
        private void WhileLoading(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                lblTarih.Text = DateTime.Now.ToString("D");
                cmbKategori.DataSource = kategoriManager.GetAll();
                cmbKategori.DisplayMember = "KategoriAdi";
                lblTabloIsmi.Text = "Gelir Tablosu";

                lblId.Visible = false;
                thenAction();

            });
        }
        private void btnGelir_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                lblTabloIsmi.Text = "Gelir Tablosu";
                thenAction();
            });
        }
        private void btnGider_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                lblTabloIsmi.Text = "Gider Tablosu";
                thenAction();
            });
        }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                ComboBox c = sender as ComboBox;
                Kategori kategori = (Kategori)c.SelectedItem;
                cmbAltKategori.Text = "";
                List<AltKategori> liste = altKategoriManager.GetAllByKategoriId(kategori.Id);
                cmbAltKategori.DataSource = liste;
                cmbAltKategori.DisplayMember = "SubKategoriAdi";
            });
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                string kategori = cmbKategori.Text;
                string altKategori = cmbAltKategori.Text;
                DateTime tarih = datetimepicker.Value;
                if (!string.IsNullOrEmpty(txtTutar.Text))
                {
                    decimal tutar = 0;
                    try
                    {
                        tutar = Convert.ToDecimal(txtTutar.Text);
                    }
                    catch (Exception)
                    {
                        Helper.Message.Error("Tutar kısmını yanlış girdiniz.");
                    }
                    string aciklama = txtAciklama.Text;
                    if (lblTabloIsmi.Text == "Gelir Tablosu")
                    {
                        gelirManager.Add(kategori, altKategori, tarih, tutar, aciklama);
                    }
                    else if (lblTabloIsmi.Text == "Gider Tablosu")
                    {
                        giderManager.Add(kategori, altKategori, tarih, tutar, aciklama);
                    }
                    thenAction();
                }
                else
                {
                    Helper.Message.Error("Tutar giriniz.");
                }
            });
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                if (lblId.Text != "Id")
                {
                    int id = Convert.ToInt32(lblId.Text);
                    if (lblTabloIsmi.Text == "Gelir Tablosu")
                    {
                        gelirManager.Delete(id);
                    }
                    else if (lblTabloIsmi.Text == "Gider Tablosu")
                    {
                        giderManager.Delete(id);
                    }
                    thenAction();
                    lblId.Text = "Id";
                }
                else
                {
                    Helper.Message.Error("Listeden bir kayıt seçiniz.");
                }
            });
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                int RowIndex = dataGridView1.CurrentCell.RowIndex;
                datetimepicker.Value = (DateTime)dataGridView1.Rows[RowIndex].Cells["KayitTarihi"].Value;
                cmbKategori.Text = dataGridView1.Rows[RowIndex].Cells["KategoriAdi"].Value.ToString();
                cmbAltKategori.Text = dataGridView1.Rows[RowIndex].Cells["AltKategoriAdi"].Value.ToString();
                txtTutar.Text = dataGridView1.Rows[RowIndex].Cells["Tutar"].Value.ToString();
                txtAciklama.Text = dataGridView1.Rows[RowIndex].Cells["Aciklama"].Value.ToString();
                int Id = (int)dataGridView1.Rows[RowIndex].Cells["Id"].Value;
                lblId.Text = Id.ToString();
            });
        }
        private void thenAction()
        {
            if (lblTabloIsmi.Text == "Gelir Tablosu")
            {
                List<Gelir> liste = gelirManager.GetAll();
                var query = from I in liste
                            orderby I.KayitTarihi descending
                            select I;
                dataGridView1.DataSource = query.ToList();
                dataGridView1.Columns["id"].Visible = false;
              lblTabloIsmi.ForeColor = System.Drawing.Color.Red;





            }
            else if (lblTabloIsmi.Text == "Gider Tablosu")
            {
                List<Gider> liste = giderManager.GetAll();
                var query = from I in liste
                            orderby I.KayitTarihi descending
                            select I;
                dataGridView1.DataSource = query.ToList();
                dataGridView1.Columns["id"].Visible = false;
              lblTabloIsmi.ForeColor = System.Drawing.Color.Yellow;



            }
            string ToplamGelir = gelirManager.Toplam();
            lblToplamGelir.Text = "Toplam Gelir : "+ToplamGelir;
            string ToplamGider = giderManager.Toplam();
            lblToplamGider.Text = "Toplam Gider : "+ToplamGider;
            decimal Kalan = Convert.ToDecimal(ToplamGelir) - Convert.ToDecimal(ToplamGider);
            lblKalan.Text = "Bakiye : "+Kalan.ToString();
            cmbKategori.Text = "";
            cmbAltKategori.Text = "";
            txtTutar.Text = "";
            txtAciklama.Text = "";
            lblId.Text = "Id";
            datetimepicker.Value = DateTime.Now;
            txtTutar.Text = "0.00";
            
        }
        private void btnAddAltKategori_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                object selectedObjectAltKategori = cmbAltKategori.SelectedItem;
                AltKategori selectedItemAltKategori = (AltKategori)selectedObjectAltKategori;
                object selectedObjectKategori = cmbKategori.SelectedItem;
                Kategori selectedItemKategori = (Kategori)selectedObjectKategori;
                AddAltKategori altKategori = new AddAltKategori(selectedItemAltKategori, selectedItemKategori);
                altKategori.ShowDialog();
            });
        }
        private void btnAddKategori_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                object selectedObject = cmbKategori.SelectedItem;
                Kategori selectedItem = (Kategori)selectedObject;
                AddKategori kategori = new AddKategori(selectedItem);
                kategori.ShowDialog();
            });
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                string kategori = cmbKategori.Text;
                string altKategori = cmbAltKategori.Text;
                DateTime tarih = datetimepicker.Value;
                decimal tutar = Convert.ToDecimal(txtTutar.Text);
                int Id = Convert.ToInt16(lblId.Text);
                string aciklama = txtAciklama.Text;
                if (lblTabloIsmi.Text == "Gelir Tablosu")
                {
                    gelirManager.Update(kategori, altKategori, tarih, tutar, aciklama, Id);
                }
                else if (lblTabloIsmi.Text == "Gider Tablosu")
                {
                    giderManager.Update(kategori, altKategori, tarih, tutar, aciklama, Id);
                }
                thenAction();
            });
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.Hata.trycatch(() => { Helper.Selenium.QuitChromeDriver(); });
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                Form openForm = Application.OpenForms["Analiz"];
                if (openForm != null)
                {
                    openForm.Focus();
                }
                else if (openForm == null)
                {
                    Analiz analizForm = new Analiz();
                    analizForm.Show();
                }
            });
        }

        private void btnToJson_Click(object sender, EventArgs e)
        {

            Helper.Hata.trycatch(() =>
            {
                if (lblTabloIsmi.Text.Contains("Gelir"))
                {
                    var listeGelir = gelirManager.GetAll();
                    string Result = Helper.JsonOperation.ToJson(listeGelir);

                    string folderPath = Helper.Files.FolderPath();
                    if (!string.IsNullOrEmpty(folderPath))
                    {
                        string selectedPath = folderPath + "\\" + "Gelir.json";
                        Helper.Files.WriteAllText(Result, selectedPath);
                        Helper.Message.Information($"Yedekleme işlemi başarılı.\n{selectedPath}");
                    }

                }
                else if (lblTabloIsmi.Text.Contains("Gider"))
                {
                    var listeGelir = giderManager.GetAll();
                    string Result = Helper.JsonOperation.ToJson(listeGelir);

                    string folderPath = Helper.Files.FolderPath();
                    if (!string.IsNullOrEmpty(folderPath))
                    {
                        string selectedPath = folderPath + "\\" + "Gider.json";
                        Helper.Files.WriteAllText(Result, selectedPath);
                        Helper.Message.Information($"Yedekleme işlemi başarılı.\n{selectedPath}");
                    }

                }
            });





        }
    }
}
