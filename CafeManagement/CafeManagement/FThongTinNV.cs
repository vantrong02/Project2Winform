using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class FThongTinNV : Form
    {
        private string maNV;
        public FThongTinNV(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void FormThongTinNV_Load(object sender, EventArgs e)
        {
            DAL_NhanVien NV = new DAL_NhanVien();
            DataTable TT_NV = NV.getNVByID(maNV);
            lb_MaNv.Text = TT_NV.Rows[0][0].ToString();
            lb_TenNV.Text = TT_NV.Rows[0][1].ToString();
            lb_Birth.Text = TT_NV.Rows[0][4].ToString();
            lb_phone.Text = TT_NV.Rows[0][5].ToString();
            lb_chucvu.Text = TT_NV.Rows[0][3].ToString();
            lb_luong.Text = TT_NV.Rows[0][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FChangePassword pass = new FChangePassword(maNV);
            pass.Show();
        }
    }
}
