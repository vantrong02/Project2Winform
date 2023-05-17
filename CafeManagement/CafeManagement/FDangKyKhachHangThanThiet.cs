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
    public partial class FDangKyKhachHangThanThiet : Form
    {
        private string sdtKH;
        private double tientra;
        public FDangKyKhachHangThanThiet(string sdtKhachHang, double tienPhaiTra)
        {
            this.tientra = tienPhaiTra;
            this.sdtKH = sdtKhachHang;
            InitializeComponent();
        }

        private void DangKyKhachHangThanThiet_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DAL_KhachHang db_KhachHang = new DAL_KhachHang();
            db_KhachHang.DangKyKhachHang(sdtKH, txtTenKhachHang.Text, tientra);
            MessageBox.Show("Đăng ký thành công!!!");
        }
    }
}
