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
    public partial class Analiz : Form
    {
        Manager.GelirManager _gelirManager;
        Manager.GiderManager _giderManager;
        Manager.KategoriManager _kategoriManager;
        public Analiz()
        {
            InitializeComponent();
            _gelirManager = new Manager.GelirManager();
            _giderManager = new Manager.GiderManager();
            _kategoriManager = new Manager.KategoriManager();
        }
        private void TarihAraligiAra_Load(object sender, EventArgs e)
        {
            Helper.Hata.trycatch(() =>
            {
                lblAciklama.Text = "* Kayıtlar bir önceki ayın 15. günü ile\n mevcut ayın 15.gününe kadar olan kısımları gösterir.";
                comboBoxAylar.SelectedIndex = ComboBoxSelection();
                ShowRecords();
                comboBoxFilitreKategori.DataSource = _kategoriManager.GetAll();
                comboBoxFilitreKategori.DisplayMember = "KategoriAdi";
                comboBoxFilitreKategori.SelectedIndex = 6;
            });
        }
        private int ComboBoxSelection()
        {
            int whichMonth = 0;
            //hangi ayı göstermesi gerektiğini söyleyen metot.
            //ayın 15 inden sonra yeni bir ayı otomatik seçecek.
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            if (Convert.ToInt32(day) < 15)
                whichMonth = Convert.ToInt32(month) - 2;
            else if (Convert.ToInt32(day) >= 15)
                whichMonth = Convert.ToInt32(month)-1;
            return whichMonth;
        }
        private void btnSearchByMonth_Click(object sender, EventArgs e)
        {
            ShowRecords();
        }
        private void ShowRecords()
        {
            int selectedIndex = comboBoxAylar.SelectedIndex;
            Helper.Hata.trycatch(() =>
            {
                int baslangicYili, bitisYili, baslangicAyi, bitisAyi, yil, ay;
                DateTime baslangicTarih, bitisTarih;
                //The following dates have been entered to set the december 2019 list as default.
                //when a different month is selected, the following default values will be updated.
                baslangicTarih = new DateTime(2019, 12, 15);
                bitisTarih = new DateTime(2020, 1, 15);
                //if no item selected in the combobox,it will throw Error
                if (selectedIndex < 0) throw new Exception("Herhangi bir ay seçimi yapmadınız.");
                yil = DateTime.Now.Year;
                ay = selectedIndex + 1;
                //if you choose different date , date are updated.
                if (selectedIndex != 12)
                {
                    baslangicTarih = new DateTime(yil, ay, 15);
                    bitisTarih = baslangicTarih.AddMonths(1);
                }
                //is showed list on datagrid
                dataGridViewGelir.DataSource = _gelirManager.GetAll(baslangicTarih, bitisTarih);
                dataGridViewGider.DataSource = _giderManager.GetAll(baslangicTarih, bitisTarih);
                dataGridViewGelir.Columns[0].Visible = false;
                dataGridViewGider.Columns[0].Visible = false;
                string _gelir = _gelirManager.ToplamTutarByDate(baslangicTarih, bitisTarih);
                string _gider = _giderManager.ToplamTutarByDate(baslangicTarih, bitisTarih);
                lblToplamGider.ForeColor = Color.IndianRed;
                lblToplamGider.Text = ": " + _gider + " TL";
                lblToplamGelir.ForeColor = Color.DarkSeaGreen;
                lblToplamGelir.Text = ": " + _gelir + " TL";
                decimal gelir, gider, kalan;
                gelir = Convert.ToDecimal(_gelir);
                gider = Convert.ToDecimal(_gider);
                kalan = gelir - gider;
                lblKalan.Text = kalan.ToString()+" TL";
                //to change label by amount of Kalan
                if (kalan > 0) lblKalan.ForeColor = Color.ForestGreen;
                else lblKalan.ForeColor = Color.IndianRed;
                lblMaastanKalan.Text = $"{comboBoxAylar.Text} ayından kalan miktar";
            });
        }
        private void ShowRecords(string filitre)
        {
            int selectedIndex = comboBoxAylar.SelectedIndex;
            Helper.Hata.trycatch(() =>
            {
                int yil, ay;
                DateTime baslangicTarih, bitisTarih;
                //The following dates have been entered to set the december 2019 list as default.
                //when a different month is selected, the following default values will be updated.
                baslangicTarih = new DateTime(2019, 12, 15);
                bitisTarih = new DateTime(2020, 1, 15);
                //if no item selected in the combobox,it will throw Error
                if (selectedIndex < 0) throw new Exception("Herhangi bir ay seçimi yapmadınız.");
                yil = DateTime.Now.Year;
                ay = selectedIndex + 1;
                //if you choose different date , date are updated.
                if (selectedIndex != 12)
                {
                    baslangicTarih = new DateTime(yil, ay, 15);
                    bitisTarih = baslangicTarih.AddMonths(1);
                }
                //is showed list on datagrid
                var listeGider = _giderManager.GetAll(baslangicTarih, bitisTarih);
                var filitreGider = from I in listeGider
                                   where I.KategoriAdi == filitre
                                   select I;
                var filitreGiderToplam = (from I in filitreGider select I.Tutar).Sum();
                dataGridViewGider.DataSource = filitreGider.ToList();
                var listeGelir = _gelirManager.GetAll(baslangicTarih, bitisTarih);
                var filitreGelir = from I in listeGelir
                                   where I.KategoriAdi == filitre
                                   select I;
                var filitreGelirToplam = (from I in filitreGelir select I.Tutar).Sum();
                dataGridViewGelir.DataSource = filitreGelir.ToList();
                //dataGridViewGelir.Columns[0].Visible = false;
                //dataGridViewGider.Columns[0].Visible = false;
                string _gelir = filitreGelirToplam.ToString();
                string _gider = filitreGiderToplam.ToString();
                lblToplamGider.ForeColor = Color.IndianRed;
                lblToplamGider.Text = ": " + _gider + " TL";
                lblToplamGelir.ForeColor = Color.DarkSeaGreen;
                lblToplamGelir.Text = ": " + _gelir + " TL";
                decimal gelir, gider, kalan;
                gelir = Convert.ToDecimal(_gelir);
                gider = Convert.ToDecimal(_gider);
                kalan = gelir - gider;
                lblKalan.Text = kalan.ToString();
                //to change label by amount of Kalan
                if (kalan > 0) lblKalan.ForeColor = Color.ForestGreen;
                else lblKalan.ForeColor = Color.IndianRed;
            });
        }
        private void btnFilitrele_Click(object sender, EventArgs e)
        {
            string cmbText = comboBoxFilitreKategori.Text;
            ShowRecords(cmbText);
        }
    }
}
