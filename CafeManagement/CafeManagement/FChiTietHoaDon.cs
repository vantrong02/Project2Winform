using System;
using System.Collections.Generic;
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
    public partial class FChiTietHoaDon : Form
    {
        public FChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Clear();
            this.Close();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            lbMaPhucVu_num.Text = FQuanLyHoaDon.maHoaDonCopy.ToString();
            lbNgayGio.Text = FQuanLyHoaDon.ngayGioCopy.ToString();
            DAL_ChiTietHoaDon db = new DAL_ChiTietHoaDon();
            DataTable dt = db.LayChiTietMotHoaDon(FQuanLyHoaDon.maHoaDonCopy, FQuanLyHoaDon.ngayGioCopy);
            DataTable chiTiet = DienChiTietVaoLV(dt);
            LoadInfoChiTietHoaDon(chiTiet);
            DienCacTong(chiTiet);
        }

        private void DienCacTong (DataTable dt)
        {
            int tongLy = 0;
            int tongTien = 0;
            int tongPhaiTra = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongLy += Convert.ToInt32(dt.Rows[i][1].ToString());
                tongTien += Convert.ToInt32(dt.Rows[i][3].ToString());
            }
            lbTongLy_num.Text = tongLy.ToString();
            lbTongTien_num.Text = tongTien.ToString();
            lbGiamGia_num.Text = FQuanLyHoaDon.giamGiaCopy.ToString();
            tongPhaiTra = tongTien - FQuanLyHoaDon.giamGiaCopy;
            lbTongPhaiTra_num.Text = tongPhaiTra.ToString();
        }

        public DataTable DienChiTietVaoLV(DataTable LayChiTiet)
        {
            DAL_ThucUong thucUongDB = new DAL_ThucUong();
            DAL_ChiTietHoaDon db = new DAL_ChiTietHoaDon();
            DataTable dt = new DataTable();
            dt.Columns.Add("HangHoa");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("ThanhTien");
            for (int i = 0; i < LayChiTiet.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["HangHoa"] = LayChiTiet.Rows[i][5].ToString();
                dr["SoLuong"] = LayChiTiet.Rows[i][7].ToString();
                dr["DonGia"] = LayChiTiet.Rows[i][6].ToString();
                dr["ThanhTien"] = double.Parse(LayChiTiet.Rows[i][7].ToString()) * double.Parse(LayChiTiet.Rows[i][6].ToString());
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void LoadInfoChiTietHoaDon(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DAL_ThucUong db = new DAL_ThucUong();
                ListViewItem lvi = lvChiTietHoaDon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        private void Clear()
        {
            lbMaPhucVu_num.Text = "";
            lbNgayGio.Text = "";
            lbTongLy_num.Text = "";
            lbTongTien_num.Text = "";
            lbGiamGia_num.Text = "";
            lbTongPhaiTra_num.Text = "";
        }

    }
}
