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
using BUS;
using CafeManagement;

namespace CafeManagement
{
    public partial class FOrder : Form
    {
        public static int soLuong;
        public static double tamTinh;
        public static double giamGia;
        public static double tienPhaiTra;
        public static string sdtKhachHang;
        public static ListView lvMonThanhToan;
        public static DateTime ngayGioHienTai;
        public static string nutDanhMuc;

        public FOrder()
        {
            InitializeComponent();
        }

        private void SaleOrder_Load(object sender, EventArgs e)
        {
            dtpNgayGioHienTai.Value = DateTime.Now;
            txtMaNhanVien.Text = FDangNhap.MaNhanVien;
            DAL_DanhMuc db_DanhMuc = new DAL_DanhMuc();
            DataTable dt = db_DanhMuc.GetDanhMuc();
            btnDM01.Text = dt.Rows[0][1].ToString();
            btnDM02.Text = dt.Rows[1][1].ToString();
            btnDM03.Text = dt.Rows[2][1].ToString();
            btnDM04.Text = dt.Rows[3][1].ToString();
        }

        private void buttonChangeColor(object sender, EventArgs e)// đỏi màu button khi click vào
        {
            foreach (Control c in panelDanhMuc.Controls)
            {
                c.BackColor = Color.PeachPuff;
            }
            Control click = (Control)sender;
            click.BackColor = Color.SandyBrown;
        }
        private void LoadInfoMonTrongDanhMuc(DataTable dt_MonTrongDanhMuc) // điền vào listview menu khi nhấn vào từng danh mục
        {
            lvMenu.Items.Clear();
            for (int i = 0; i < dt_MonTrongDanhMuc.Rows.Count; i++)
            {
                ListViewItem lv = lvMenu.Items.Add((dt_MonTrongDanhMuc.Rows[i][0]).ToString());
                lv.SubItems.Add(dt_MonTrongDanhMuc.Rows[i][1].ToString());
                lv.SubItems.Add(dt_MonTrongDanhMuc.Rows[i][2].ToString());
                lv.SubItems.Add((dt_MonTrongDanhMuc.Rows[i][3]).ToString());
            }
        }

        private void btnToanBoMon_Click(object sender, EventArgs e)
        {
            buttonChangeColor(btnToanBoMon, null);
            try
            {
                DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
                DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc(" ");
                LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDM01_Click_1(object sender, EventArgs e)
        {
            buttonChangeColor(btnDM01, null);
            nutDanhMuc = btnDM01.Text;
            try
            {
                DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
                DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc("DM01");
                LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDM02_Click(object sender, EventArgs e)
        {
            buttonChangeColor(btnDM02, null);
            nutDanhMuc = btnDM02.Text;
            try
            {
                DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
                DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc("DM02");
                LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDM03_Click(object sender, EventArgs e)
        {
            buttonChangeColor(btnDM03, null);
            nutDanhMuc = btnDM03.Text;
            try
            {
                DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
                DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc("DM03");
                LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDM04_Click(object sender, EventArgs e)
        {
            buttonChangeColor(btnDM04, null);
            nutDanhMuc = btnDM04.Text;
            try
            {
                DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
                DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc("DM04");
                LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearBox()
        {
            lvMonDaChon.Items.Clear();
            txtTamTinh.Clear();
            txtGiamGia.Clear();
            txtSDT.Clear();
            txtSoLuong.Clear();
            txtSoLuongMoiMon.Clear();
            txtSoTienPhaiTra.Clear();
        }
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void FillTxtTamTinh(ListView lvMonDaChon, double TamTinh) // sau mỗi lần chọn món và nhập số lượng, thưc hiện tính lại tổng hóa đơn khi chưa giảm giá
        {
            DAL_HoaDon db_TamTinh = new DAL_HoaDon();
            double ThanhTien = 0;

            for (int i = 0; i < lvMonDaChon.Items.Count; i++)
            {
                ThanhTien = Convert.ToDouble(lvMonDaChon.Items[i].SubItems[3].Text);
                TamTinh = db_TamTinh.TinhTamTinh(TamTinh, ThanhTien);
                txtTamTinh.Text = TamTinh.ToString();
            }

        }
        private void FilltxtSoLuong(ListView lvMonDaChon, int SoLuong)
        {
            for (int i = 0; i < lvMonDaChon.Items.Count; i++)
            {
                SoLuong = SoLuong + Convert.ToInt16(lvMonDaChon.Items[i].SubItems[2].Text);
                txtSoLuong.Text = SoLuong.ToString();
            }
        }

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e) // Món được chọn bên bảng menu sẽ được thêm vào listview món đã chọn
        {
            try
            {
                if (lvMenu.SelectedItems.ToString() != null && lvMenu.SelectedItems.Count > 0)
                {
                    if (int.Parse(lvMenu.SelectedItems[0].SubItems[3].Text) != 0)
                    {
                        ListViewItem MonDuocChon = lvMenu.SelectedItems[0];
                        ListViewItem lv = lvMonDaChon.Items.Add(MonDuocChon.SubItems[1].Text);
                        lv.SubItems.Add(MonDuocChon.SubItems[2].Text);
                        txtSoLuongMoiMon.Text = Convert.ToString(1);
                        lv.SubItems.Add(txtSoLuongMoiMon.Text);
                        double DonGia = Convert.ToDouble(MonDuocChon.SubItems[2].Text); //Chọn đơn giá từ listview menu
                        int SoLuong = Convert.ToInt16(lv.SubItems[2].Text); // Chọn số lượng món từ listview chi tiết hóa đơn
                        DAL_ChiTietHoaDon db_ThanhTien = new DAL_ChiTietHoaDon();
                        double ThanhTien = db_ThanhTien.TinhThanhTien(DonGia, SoLuong);
                        lv.SubItems.Add(ThanhTien.ToString());

                        txtTamTinh.Text = "0";
                        FillTxtTamTinh(lvMonDaChon, Convert.ToDouble(txtTamTinh.Text));//Hiển thị lại Số tiền tạm tính sau khi thêm món mới

                        txtSoLuong.Text = "0";
                        FilltxtSoLuong(lvMonDaChon, Convert.ToInt16(txtSoLuong.Text));

                        txtGiamGia.Text = "0";
                        txtSoTienPhaiTra.Text = txtTamTinh.Text;
                    }
                    else
                        MessageBox.Show("Món tạm hết", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DAL_ChiTietHoaDon db_ThanhTien = new DAL_ChiTietHoaDon();
            if (lvMonDaChon.SelectedItems.Count == 0)
            {
                ListViewItem lv = lvMonDaChon.Items[lvMonDaChon.Items.Count - 1];
                lv.SubItems[2].Text = txtSoLuongMoiMon.Text;
                double DonGia = Convert.ToDouble(lv.SubItems[1].Text); //Chọn đơn giá từ listview các món đã chọn
                int SoLuong = Convert.ToInt16(lv.SubItems[2].Text); // Chọn số lượng món từ listview các món đã chọn
                double ThanhTien = db_ThanhTien.TinhThanhTien(DonGia, SoLuong);
                lv.SubItems[3].Text = (ThanhTien.ToString());

            }
            else
            {
                ListViewItem lv = lvMonDaChon.SelectedItems[0];
                lv.SubItems[2].Text = txtSoLuongMoiMon.Text;
                double DonGia = Convert.ToDouble(lv.SubItems[1].Text); //Chọn đơn giá từ listview các món đã chọn
                int SoLuong = Convert.ToInt16(lv.SubItems[2].Text); // Chọn số lượng món từ listview các món đã chọn
                double ThanhTien = db_ThanhTien.TinhThanhTien(DonGia, SoLuong);
                lv.SubItems[3].Text = (ThanhTien.ToString());
            }
            txtTamTinh.Text = "0";
            FillTxtTamTinh(lvMonDaChon, Convert.ToDouble(txtTamTinh.Text));

            txtSoLuong.Text = "0";
            FilltxtSoLuong(lvMonDaChon, Convert.ToInt16(txtSoLuong.Text));

            txtGiamGia.Text = "0";

            txtSoTienPhaiTra.Text = txtTamTinh.Text;


        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(txtSoLuongMoiMon.Text) < int.Parse(lvMenu.SelectedItems[0].SubItems[3].Text))
                    txtSoLuongMoiMon.Text = Convert.ToString(int.Parse(txtSoLuongMoiMon.Text) + 1);
                else
                    MessageBox.Show("Số lượng món đã đạt đến giới hạn", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa chọn món cần thêm số lượng");
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (txtSoLuongMoiMon.Text == "1")
            {
                DialogResult choosed = MessageBox.Show("Bạn có chắc xóa thức uống này ?", "Yes/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (choosed == DialogResult.Yes)
                {
                    lvMonDaChon.Items.RemoveAt(lvMonDaChon.Items.Count - 1);
                }
            }
            else
                txtSoLuongMoiMon.Text = Convert.ToString(int.Parse(txtSoLuongMoiMon.Text) - 1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvMonDaChon.SelectedItems.Count != 0)
                {
                    DialogResult choosed = MessageBox.Show("Bạn có chắc xóa thức uống này ?", "Yes/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (choosed == DialogResult.Yes)
                    {
                        lvMonDaChon.Items.Remove(lvMonDaChon.SelectedItems[0]);
                        txtTamTinh.Text = "0";
                        FillTxtTamTinh(lvMonDaChon, Convert.ToDouble(txtTamTinh.Text));
                        txtSoTienPhaiTra.Text = txtTamTinh.Text;
                    }

                }
                else
                    MessageBox.Show("Bạn chưa chọn món cần xóa ?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            DAL_KhachHang db_KhachHang = new DAL_KhachHang();
            DAL_HoaDon db_HoaDon = new DAL_HoaDon();
            if (txtGiamGia.Text != "0") // Đã là khách hàng thân thiết và đã chọn sử dụng điểm tích lũy
                                        //--> cần cập nhật lại cả điểm tích lũy với biến sử dụng điểm là 1 và tổng chi tiêu của khách hàng sau đó mới thêm HĐ
            {
                db_KhachHang.CapNhatDiemTichLuy(txtSDT.Text, double.Parse(txtSoTienPhaiTra.Text), 1);
                MessageBox.Show("Bạn sử dụng " + int.Parse(txtGiamGia.Text) / 1000 + " điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db_KhachHang.CapNhatTongChiTieu(txtSDT.Text, double.Parse(txtSoTienPhaiTra.Text));

            }
            else
            {
                CheckKhachHang check = new CheckKhachHang();
                if (check.CheckKhachHangThanThiet(txtSDT.Text) == true) //là khách hàng thân thiết nhưng lựa chọn tích điểm chứ không giảm giá
                                                                        //--> Cần cập nhật lại điểm tích lũy với biến sử dụng điểm là 0 và tổng chi tiêu
                {
                    //db_KhachHang.CapNhatDiemTichLuy(txtSDT.Text, double.Parse(txtSoTienPhaiTra.Text), 0);
                    MessageBox.Show("Bạn được cộng thêm " + int.Parse(txtTamTinh.Text) / 20000 + " điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db_KhachHang.CapNhatTongChiTieu(txtSDT.Text, double.Parse(txtSoTienPhaiTra.Text));

                }
                // Không cung cấp SDT --> Không có nhu cầu giảm giá hoặc tính điểm hoặc
                // Đã nhập số điện thoại để kiểm tra nhưng không phải là khách hàng thân thiết
                //--> không cần cập nhật điểm tích lũy và tổng chi tiêu của khách hàng, chỉ cần thêm hóa đơn
            }
            db_HoaDon.ThemHoaDon(txtSDT.Text, txtMaNhanVien.Text, double.Parse(txtTamTinh.Text), double.Parse(txtGiamGia.Text));


            //Thêm chi tiết hóa đơn
            DAL_ChiTietHoaDon db_ChiTietHoaDon = new DAL_ChiTietHoaDon();
            DAL_ThucUong db_ThucUong = new DAL_ThucUong();
            for (int i = 0; i < lvMonDaChon.Items.Count; i++)
            {
                string maThucUong = db_ThucUong.GetMaThucUong(lvMonDaChon.Items[i].SubItems[0].Text);
                db_ChiTietHoaDon.ThemChiTietHoaDon(maThucUong, int.Parse(lvMonDaChon.Items[i].SubItems[2].Text));
            }

            //Cập nhật lại số lượng món còn lại trong menu
            DAL_SaleOrder db_ThucUongTrongDanhMuc = new DAL_SaleOrder();
            DataTable dt_ThucUongTrongDanhMuc = db_ThucUongTrongDanhMuc.GetMonTrongMoiDanhMuc(nutDanhMuc);
            LoadInfoMonTrongDanhMuc(dt_ThucUongTrongDanhMuc);

            // Xuất ra bill
            soLuong = int.Parse(txtSoLuong.Text);
            tamTinh = double.Parse(txtTamTinh.Text);
            giamGia = double.Parse(txtGiamGia.Text);
            tienPhaiTra = double.Parse(txtSoTienPhaiTra.Text);
            lvMonThanhToan = lvMonDaChon;
            ngayGioHienTai = dtpNgayGioHienTai.Value;
            sdtKhachHang = txtSDT.Text;

            FXuatHoaDon xuatHoaDon = new FXuatHoaDon(ngayGioHienTai, txtMaNhanVien.Text, sdtKhachHang);
            xuatHoaDon.Show();
            ClearBox();

        }


        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != "")
            {

                DAL_HoaDon db_GiamGia = new DAL_HoaDon();
                CheckKhachHang Check = new CheckKhachHang();
                int soDiemTichOHoaDonHienTai = int.Parse(txtTamTinh.Text) / 20000;
                if (Check.CheckKhachHangThanThiet(txtSDT.Text) == true) // Nếu khách hàng đã là khách hàng thân thiết
                {
                    DialogResult choosed = MessageBox.Show("Đã là khách hàng thân thiết. Điểm tích ở hóa đơn hiện tại là " + soDiemTichOHoaDonHienTai +". Sử dụng điểm tích lũy.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (choosed == DialogResult.Yes) // chọn giảm giá
                    {
                        txtGiamGia.Text = db_GiamGia.TinhGiamGia(txtSDT.Text, double.Parse(txtTamTinh.Text)).ToString();
                    }
                    else
                        txtGiamGia.Text = "0";

                }
                else // Chưa là khách hàng thân thiết của quán
                {
                    if (Check.CheckDKDangKyKhachHang(double.Parse(txtTamTinh.Text)) == true)// Kiểm tra đã đủ điều kiện đăng kí chưa
                    {
                        DialogResult choosed = MessageBox.Show("Đủ điều kiện. Bạn có muốn đăng ký khách hàng thân thiết?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (choosed == DialogResult.Yes)
                        {
                            FDangKyKhachHangThanThiet DangKy = new FDangKyKhachHangThanThiet(txtSDT.Text, double.Parse(txtSoTienPhaiTra.Text));
                            DangKy.Show();
                        }
                    }
                    else// nếu chưa đủ điều kiện đăng kí
                    {
                        MessageBox.Show("Bạn chưa đủ điều kiện để đăng ký khách hàng thân thiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                txtSoTienPhaiTra.Text = (double.Parse(txtTamTinh.Text) - double.Parse(txtGiamGia.Text)).ToString();
            }
            else
                MessageBox.Show("Chưa nhập số điện thoại khách hàng");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DAL_NhanVien db = new DAL_NhanVien();
            db.CapNhatSoGioLam(FDangNhap.GioDangNhap, DateTime.Now, txtMaNhanVien.Text);
            this.Hide();
            FDangNhap login = new FDangNhap();
            login.Show();
        }

        private void bt_info_Click(object sender, EventArgs e)
        {
            FThongTinNV NV = new FThongTinNV(txtMaNhanVien.Text);
            NV.Show();
        }
    }
}
