using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace CafeManagement
{
    public partial class FThongKe : Form
    {
        DAL_DoanhThu db = new DAL_DoanhThu();
        public FThongKe()
        {
            InitializeComponent();
            
           
        }
        private void resetRadio()
        {
            rdoCheckHomNay.Checked = false;
            rdoCheckTheoNam.Checked = false;
            rdoCheckTheoNgay.Checked = false;
            rdoCheckTheoThang.Checked = false;
        }
        private void LoadListDoanhThu(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime Ngay = DateTime.Parse(dt.Rows[i][0].ToString());

                string strNgay = FQuanLyNhanVien.FormatDate(Ngay);

                ListViewItem lvi = lvDoanhThu.Items.Add(strNgay);
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        private void LoadListSanPham(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lvSanPhamTheoDoanhThu.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add((double.Parse(dt.Rows[i][3].ToString())).ToString());
                //double TongTien = double.Parse(dt.Rows[i][3].ToString());
                lvi.SubItems.Add((double.Parse(dt.Rows[i][4].ToString())).ToString());
            }
        }

        private void rdoCheckHomNay_CheckedChanged(object sender, EventArgs e)
        {
            lvSanPhamTheoDoanhThu.Items.Clear();
            chartDoanhThu.Hide();
            chart1.Hide();
            if(rdoCheckHomNay.Checked)
            {
                lvDoanhThu.Items.Clear();
                DAL_DoanhThu db = new DAL_DoanhThu();
                DataTable dt = db.getDoanhThuHomNay();
                LoadListDoanhThu(dt);

            }    
        }

        private void rdoCheckTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            //lvSanPhamTheoDoanhThu.Items.Clear();
            //chartDoanhThu.Hide();
            //chart1.Hide();
            lvSanPhamTheoDoanhThu.Items.Clear();
            chartDoanhThu.Series["Doanh Thu (VND)"].Points.Clear();
            chartDoanhThu.Show();
            if (rdoCheckTheoNgay.Checked)
            {
                lvDoanhThu.Items.Clear();
                DAL_DoanhThu db = new DAL_DoanhThu();
                DataTable dt = db.getDoanhThuTheoNgay();
                LoadListDoanhThu(dt);
            }
        }

        private void rdoCheckTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            lvSanPhamTheoDoanhThu.Items.Clear();
            chartDoanhThu.Series["Doanh Thu (VND)"].Points.Clear();
            chartDoanhThu.Show();
            
            DAL_DoanhThu db = new DAL_DoanhThu();
            if (rdoCheckTheoThang.Checked)
            {
                lvDoanhThu.Items.Clear();

                DataTable dt = db.getDoanhThuTheoThang();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Thang = "Tháng " + dt.Rows[i][0].ToString();
                    ListViewItem lvi = lvDoanhThu.Items.Add(Thang);
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                }
                //chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
               

                var month = new ArrayList() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < month.Count; j++)
                    {
                        if (int.Parse(dt.Rows[i][0].ToString()) == j + 1)
                        {
                            month[j] = dt.Rows[i][3].ToString();
                            string thang = (j + 1).ToString();
                            chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T" + thang, month[j]);
                        }
                    }

                }
                chartDoanhThu.Series["Doanh Thu (VND)"].IsValueShownAsLabel = true;







            }


            // chartDoanhThu.DataSource = db.getDoanhThuTheoThang()
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T1", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T2", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T3", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T4", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T5", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T6", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T7", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T8", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T9", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T10", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T11", 0);
            //chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY("T12", 0);
        }
        private void rdoCheckTheoNam_CheckedChanged(object sender, EventArgs e)
        {
            lvSanPhamTheoDoanhThu.Items.Clear();
            chartDoanhThu.Series["Doanh Thu (VND)"].Points.Clear();
            chart1.Series["Revenue"].Points.Clear();
            chart1.Hide();
            if (rdoCheckTheoNam.Checked)
            {
                chartDoanhThu.Series["Doanh Thu (VND)"].Points.Clear();
                chartDoanhThu.Show();
                lvDoanhThu.Items.Clear();
                DAL_DoanhThu db = new DAL_DoanhThu();
                DataTable dt = db.getDoanhThuTheoNam();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Nam = "Năm " + dt.Rows[i][0].ToString();
                    ListViewItem lvi = lvDoanhThu.Items.Add(Nam);
                    lvi.SubItems.Add(dt.Rows[i][1].ToString());
                    lvi.SubItems.Add(dt.Rows[i][2].ToString());
                    lvi.SubItems.Add(dt.Rows[i][3].ToString());
                    chartDoanhThu.Series["Doanh Thu (VND)"].Points.AddXY(dt.Rows[i][0].ToString(), dt.Rows[i][3].ToString());
                }

            }
        }

        private void btnXemNgayTuyChon_Click(object sender, EventArgs e)
        {
            lvSanPhamTheoDoanhThu.Items.Clear();
            chartDoanhThu.Hide();
            resetRadio();
            lvDoanhThu.Items.Clear();
            int check = DateTime.Compare(Convert.ToDateTime(dtpNgayKetThuc.Value.ToString()), Convert.ToDateTime(dtpNgayBatDau.Value.ToString()));
            if (check ==-1)
            {
                MessageBox.Show("Ngày không hợp lệ!! Vui lòng chọn lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string BeginDate = dtpNgayBatDau.Value.ToString("yyyy-MM-dd");
                string EndDate = dtpNgayKetThuc.Value.ToString("yyyy-MM-dd");
                DAL_DoanhThu db = new DAL_DoanhThu();
                DataTable dt = db.getDoanhThuTuyChon(BeginDate, EndDate);
                LoadListDoanhThu(dt);
            }
            
            
        }
        private int NgayTrongThang(int th, int nam)
        {
            int songay = 0;
            if (th >= 1 && th <= 12)
            {
                switch (th)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: songay = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: songay = 30; break;

                    case 2:
                        if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))    // nam nhuan
                            songay = 29;
                        else
                            songay = 28;
                        break;
                }
            }
            return songay;
        }
        private void lvDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDoanhThu.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDoanhThu.SelectedItems[0];
                string date = item.SubItems[0].Text;
                lvSanPhamTheoDoanhThu.Items.Clear();
                DataTable dt = new DataTable();
                DAL_NhanVien dbNV = new DAL_NhanVien();
                DAL_DoanhThu dbDT = new DAL_DoanhThu();

                /*if (rdoCheckHomNay.Checked == true|| rdoCheckTheoNgay.Checked==true)
                {
                    date = item.SubItems[0].Text;
                    string day = convertFormatDate(date);
                    dt = db.loadSanPhamTheoDoanhThu(day, day);
                    
                }*/
                DataTable tableNhanVien = dbNV.getNhanVien();
                ArrayList listNhanVien = new ArrayList();
                ArrayList value = new ArrayList();
                for (int i = 0; i < tableNhanVien.Rows.Count; i++)
                {

                    listNhanVien.Add(tableNhanVien.Rows[i][1].ToString());
                    value.Add(0);
                }
                if (rdoCheckTheoThang.Checked)
                {
                    int day = NgayTrongThang(int.Parse(date.Replace("Tháng", "")),int.Parse(DateTime.Now.Year.ToString()));
                    date = DateTime.Now.Year.ToString() + "-" + date.Replace("Tháng", "") + "-";
                    dt = db.loadSanPhamTheoDoanhThu(date+"01", date+ Convert.ToString(day));
                    chart1.Series["Revenue"].Points.Clear();
                    chart1.Show();
                    
                    int month = int.Parse(item.SubItems[0].Text.Replace("Tháng ", ""));
                    DataTable dtDoanhThuTheoThang = dbNV.NhanVienXuatSacTheoThang(month);
                    for (int i = 0; i < dtDoanhThuTheoThang.Rows.Count; i++)
                    {
                        for (int j = 0; j < listNhanVien.Count; j++)
                        {
                            if (dtDoanhThuTheoThang.Rows[i][1].ToString() == listNhanVien[j].ToString())
                            {
                                value[j] = dtDoanhThuTheoThang.Rows[i][2];
                            }
                        }    
                    }   
                    for (int i = 0; i< listNhanVien.Count; i++)
                    {
                        
                        chart1.Series["Revenue"].Points.AddXY(listNhanVien[i], value[i]);
                    }
                    chart1.Series["Revenue"].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].BackColor = Color.Linen;

                }
                else if(rdoCheckTheoNam.Checked)
                {
                    date = date.Replace("Năm", "") + "-";
                    dt = dbDT.loadSanPhamTheoDoanhThu(date + "01-01", date + "12-31");
                    chart1.Series["Revenue"].Points.Clear();
                    chart1.Show();

                    int year = int.Parse(item.SubItems[0].Text.Replace("Năm ", ""));
                    DataTable dtDoanhThuTheoNam = dbNV.NhanVienXuatSacTheoNam(year);
                    for (int i = 0; i < dtDoanhThuTheoNam.Rows.Count; i++)
                    {
                        for (int j = 0; j < listNhanVien.Count; j++)
                        {
                            if (dtDoanhThuTheoNam.Rows[i][1].ToString() == listNhanVien[j].ToString())
                            {
                                value[j] = dtDoanhThuTheoNam.Rows[i][2];
                            }
                        }
                    }
                    for (int i = 0; i < listNhanVien.Count; i++)
                    {

                        chart1.Series["Revenue"].Points.AddXY(listNhanVien[i], value[i]);
                    }
                    chart1.Series["Revenue"].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].BackColor = Color.Linen;
                } 
                else
                {
                    date = item.SubItems[0].Text;
                    string day = convertFormatDate(date);
                    dt = db.loadSanPhamTheoDoanhThu(day, day);
                }    
                LoadListSanPham(dt);

            }
        }

        public string convertFormatDate(string date)
        {
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            return year + "-" + month + "-" + day;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.MaxDate = DateTime.Now;
            dtpNgayKetThuc.MaxDate = DateTime.Now;
            dtpNgayBatDau.Value = dtpNgayBatDau.MaxDate;
            dtpNgayKetThuc.Value = dtpNgayKetThuc.MaxDate;
            chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartDoanhThu.ChartAreas[0].AxisX.MinorGrid.LineWidth = 0;
            chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartDoanhThu.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartDoanhThu.ChartAreas[0].BackColor = Color.Linen;

            chartDoanhThu.Hide();
            chart1.Hide();
            //chartNhanVien.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            //chartNhanVien.ChartAreas[0].AxisX.MinorGrid.LineWidth = 0;
            //chartNhanVien.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            //chartNhanVien.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;

            

        }

        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chartNhanVien_Click(object sender, EventArgs e)
        {
            
        }
    }
}
