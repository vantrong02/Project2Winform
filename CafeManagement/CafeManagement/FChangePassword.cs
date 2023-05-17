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
    public partial class FChangePassword : Form
    {
        private string manv;
        public FChangePassword(string maNV)
        {
            this.manv = maNV;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = Convert.ToChar("*");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = Convert.ToChar("*");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = Convert.ToChar("*");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.PasswordChar = (char)0;
            }
            else
            {
                textBox1.PasswordChar = Convert.ToChar("*");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = Convert.ToChar("*");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.PasswordChar = (char)0;
            }
            else
            {
                textBox3.PasswordChar = Convert.ToChar("*");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL_NhanVien NV = new DAL_NhanVien();
            DataTable TT_NV = NV.getNVByID(manv);
            if(textBox1.Text == TT_NV.Rows[0][2].ToString())
            {
                if(textBox2.Text == textBox3.Text)
                {
                    NV.SuaPassword(textBox2.Text, manv);
                    MessageBox.Show("Đổi mật khẩu thành công!!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp !!");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác!!");
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
