using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vacuumControl
{
    public partial class Form1 : Form
    {
        public static Employee LoginUser;
        DataModel dm = new DataModel();
        int QualityID = 0;
        int FaultID = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoginPage frm = new LoginPage();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Assume Helpers.isLogin is a static property holding the logged-in user's info
                Employee model = Helpers.isLogin;
                Form1.LoginUser.ID = model.ID; // Assuming QualityPersonalID is obtained from the logged-in user
            }
            loadGrid();
        }

        private void tb_barcode_Enter(object sender, EventArgs e)
        {

        }

        private void tb_status_Enter(object sender, EventArgs e)
        {

        }

        private void loadGrid()
        {
            var result = dm.logEntryListVacuumTest(new VacuumTest
            {
                Barcode = tb_barcode.Text,
                Result = tb_status.Text
            });

            if (result != null)
            {
                var rt = result.OrderByDescending(r => r.ID).ToList();
                DataTable dt = new DataTable();

                dt.Columns.Add("ID");
                dt.Columns.Add("Barkod No");
                dt.Columns.Add("Kalite");
                dt.Columns.Add("Sonuç");
                dt.Columns.Add("Kontrol Tarihi");
                dt.Columns.Add("Vakum Personeli");

                foreach (var item in rt)
                {
                    DataRow r = dt.NewRow();
                    r["ID"] = item.ID;
                    r["Barkod No"] = item.Barcode;
                    r["Kalite"] = item.Quality;
                    r["Sonuç"] = item.Result;
                    r["Kontrol Tarihi"] = item.Datetime.ToShortDateString();
                    r["Vakum Personeli"] = item.QualityPersonal;
                    dt.Rows.Add(r);
                }

                dgv_controlList.DataSource = dt;
                lbl_number.Text = "Bakılan Ürün sayısı: " + dgv_controlList.RowCount;
            }
            else
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu.");
            }
            tb_barcode.Select();
        }

        private void tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_barcode.Text.Length == 10)
                {
                    if (dm.isThereBarcode(tb_barcode.Text))
                    {
                        tb_status.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kalite Masasına Uğramamış");
                        tb_barcode.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli Barkod Numarası Giriniz");
                    tb_barcode.Text = "";
                }
            }
        }

        private void tb_status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_status.Text.Length == 2)
                {
                    VacuumTest vt = new VacuumTest();
                    if (dm.isThereFault(Convert.ToInt32(tb_status.Text)))
                    {
                        vt.Barcode = tb_barcode.Text;
                        vt.QualityID = cb_fire.Checked ? 5 : dm.getBarcodeQuality(tb_barcode.Text).FirstOrDefault()?.QualityID ?? 0;
                        if (vt.QualityID == 5)
                        {
                            dm.updateProductQuality(vt);
                        }
                        vt.ResultID = Convert.ToInt32(tb_status.Text);
                        vt.Datetime = DateTime.Now;
                        vt.QualityPersonalID = Form1.LoginUser.ID;

                        if (dm.createVacuumTest(vt))
                        {
                            tb_barcode.Text = tb_status.Text = "";
                            loadGrid(); // Refresh the grid after saving
                        }
                        else
                        {
                            MessageBox.Show("Vakum testi kaydedilemedi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz arıza kodu.");
                        tb_status.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Sonuç girilmedi.");
                }
            }
        }

    }
}
