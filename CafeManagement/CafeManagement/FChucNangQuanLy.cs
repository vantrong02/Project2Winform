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
    public partial class FChucNangQuanLy : Form
    {
        public FChucNangQuanLy()
        {
            InitializeComponent();
            
        }

        private Form currentForm;
        private void OpenChildForm (Form childForm)
        {
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void buttonChangeColor(object sender, EventArgs e)
        {
            foreach (Control c in btnpanel.Controls)
            {
                c.BackColor = Color.PeachPuff;
            }
            Control click = (Control)sender;
            click.BackColor = Color.SandyBrown;
        }
        

        //private void btnTrangChu_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new TrangChu());
        //    buttonChangeColor(btnTrangChu, null);
        //}

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FQuanLyMon());
            buttonChangeColor(btnThucDon, null);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FQuanLyDanhMuc());
            buttonChangeColor(btnDanhMuc, null);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FQuanLyHoaDon());
            buttonChangeColor(btnHoaDon, null);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FThongKe());
            buttonChangeColor(btnDoanhThu, null);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FQuanLyNhanVien());
            buttonChangeColor(btnNhanVien, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FDangNhap login = new FDangNhap();
            login.Show();
            this.Hide();

        }

        private void ChucNangQuanLy_Load(object sender, EventArgs e)
        {
            
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {
            FTrangChu child = new FTrangChu() { TopLevel = false, TopMost = true };
            child.FormBorderStyle = FormBorderStyle.None;
            panelBody.Controls.Add(child);
            child.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FQuanLyKhachHang());
            buttonChangeColor(btnKhachHang, null);
        }
    }
}
