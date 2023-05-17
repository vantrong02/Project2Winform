using System;
using System.IO;
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
    public partial class FXuatHoaDon : Form
    {
        private DateTime ngayGioHienTai;
        private string maNV;
        private string maKH;
        public FXuatHoaDon(DateTime ngayGioHienTai, string manv, string maKH)
        {
            InitializeComponent();

            this.ngayGioHienTai = ngayGioHienTai;
            this.maNV = manv;
            this.maKH = maKH;
        }

        private void XuatHoaDon_Load(object sender, EventArgs e)
        {
            DAL_SaleOrder db_SaleOrder = new DAL_SaleOrder();
            DAL_NhanVien db_NhanVien = new DAL_NhanVien();
            DAL_KhachHang db_KhachHang = new DAL_KhachHang();
            if (maKH != "")
            {
                string tenKH = db_KhachHang.GetTenKH(maKH);
                lbTenKhachHang.Text = tenKH;
            }
            else
            {
                lbTenKhachHang.Text = "Guest";
            }
            string tenNV = db_NhanVien.GetTenNVTheoMa(maNV);
            int maPhucVu = db_SaleOrder.LayMaHoaDonHienTai(ngayGioHienTai);
            lbMaPhucVu_num.Text = maPhucVu.ToString();
            lbTenNhanVien.Text = tenNV;
            lbNgayGio.Text = ngayGioHienTai.ToString();
            

            DAL_ChiTietHoaDon db = new DAL_ChiTietHoaDon();
            ListView chiTiet = FOrder.lvMonThanhToan;
            LoadInfoXuatHoaDon(chiTiet);
            DienCacTong();
        }

        private void DienCacTong()
        {
            lbTongLy_num.Text = FOrder.soLuong.ToString();
            lbTongTien_num.Text = FOrder.tamTinh.ToString();
            lbGiamGia_num.Text = FOrder.giamGia.ToString();
            lbTongPhaiTra_num.Text = FOrder.tienPhaiTra.ToString();

        }

        private void LoadInfoXuatHoaDon(ListView chiTiet)
        {
            //DB_ChiTietHoaDon db = new DB_ChiTietHoaDon();
            //DataTable dt = db.LayChiTietMotHoaDon();
            for (int i = 0; i < chiTiet.Items.Count; i++)
            {
                DAL_ThucUong db = new DAL_ThucUong();
                ListViewItem lvi = lvXuatHoaDon.Items.Add(chiTiet.Items[i].SubItems[0].Text);
                lvi.SubItems.Add(chiTiet.Items[i].SubItems[2].Text);
                lvi.SubItems.Add(chiTiet.Items[i].SubItems[1].Text);
                lvi.SubItems.Add(chiTiet.Items[i].SubItems[3].Text);
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Clear();
            this.Close();
        }

        public void InHoaDon()
        {
            DAL_NhanVien db_NhanVien = new DAL_NhanVien();
            string tenNV = db_NhanVien.GetTenNVTheoMa(maNV);
            string filePath = lbMaPhucVu_num.Text;
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            dialog.Title = "Hóa Đơn " + lbMaPhucVu_num.Text;
            //Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            Microsoft.Office.Interop.Excel.Application exApp;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            try
            {
                //Tạo đối tượng COM.
                exApp = new Microsoft.Office.Interop.Excel.Application();
                exApp.Visible = false;
                exApp.DisplayAlerts = false;
                //workBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                workBook = exApp.Workbooks.Add(Type.Missing);
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets["Sheet1"];

                workSheet.Name = "Hóa đơn bán hàng";
                workSheet.Cells.Style.Font.Size = 12;
                workSheet.Cells.Style.Font.Name = "Calibri";

                workSheet.Cells[1, 1].Value = "THE COFFEE HOUSE";
                workSheet.Cells[1, 1].Font.Size = 14;
                workSheet.Cells[1, 1].Font.Bold = true;
                workSheet.Cells[2, 1].Value = "Địa Chỉ: Thủ Đức, Hồ Chí Minh";
                workSheet.Cells[3, 1].Value = "Điện thoại: 1234567";
                workSheet.Cells[4, 2].Value = "HÓA ĐƠN BÁN HÀNG";
                workSheet.Cells[4, 2].Font.Size = 20;
                workSheet.Cells[4, 2].Font.Bold = true;

                workSheet.Cells[5, 1].Value = "Ngày xuất phiếu:";
                workSheet.Cells[5, 1].Font.Bold = true;
                workSheet.Cells[5, 4].Value = DateTime.Now;

                workSheet.Cells[6, 1].Value = "Mã hóa đơn:";
                workSheet.Cells[6, 1].Font.Bold = true;
                workSheet.Cells[6, 4].Value = lbMaPhucVu_num.Text;

                workSheet.Cells[7, 1].Value = "Tổng ly:";
                workSheet.Cells[7, 1].Font.Bold = true;
                workSheet.Cells[7, 4].Value = lbTongLy_num.Text;

                workSheet.Cells[8, 1].Value = "Tổng tiền:";
                workSheet.Cells[8, 1].Font.Bold = true;
                workSheet.Cells[8, 4].Value = lbTongTien_num.Text;

                workSheet.Cells[9, 1].Value = "Giảm giá:";
                workSheet.Cells[9, 1].Font.Bold = true;
                workSheet.Cells[9, 4].Value = lbGiamGia_num.Text;

                workSheet.Cells[10, 1].Value = "Tên khách hàng:";
                workSheet.Cells[10, 1].Font.Bold = true;
                workSheet.Cells[10, 3].Value = lbTenKhachHang.Text;

                workSheet.Cells[11, 1].Value = "Nhân viên:";
                workSheet.Cells[11, 1].Font.Bold = true;
                workSheet.Cells[11, 3].Value = tenNV;

                for (int i = 1; i <= lvXuatHoaDon.Columns.Count; i++)
                {
                    workSheet.Cells[12, i] = lvXuatHoaDon.Columns[i-1].Text;
                    workSheet.Cells[12, i].Font.Bold = true;
                    workSheet.Cells[12, i].Borders.LineStyle = true;
                    workSheet.Cells[12, i].ColumnWidth = 15;

                }

                int lasti = 0, lastj = 0;
                for (int i = 0; i < lvXuatHoaDon.Items.Count; i++)
                {
                    lasti = i;
                    for (int j = 1; j <= lvXuatHoaDon.Columns.Count; j++)
                    {
                        lastj = j;
                        workSheet.Cells[i + 13, j] = lvXuatHoaDon.Items[i].SubItems[j-1].Text;
                        workSheet.Cells[i + 13, j].Borders.LineStyle = true;
                    }
                }
                workSheet.Cells[lasti + 14, lastj - 1] = "Tổng cộng:";
                workSheet.Cells[lasti + 14, lastj] = lbTongPhaiTra_num.Text;

                workBook.Activate();
                workBook.SaveAs(filePath);
                workBook.Save();
                workBook.Close();
                exApp.Quit();
                bool flag = SaveAsPdf(filePath);
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workBook = null;
                workSheet = null;
            }
        }
        private bool SaveAsPdf(string saveAsLocation)
        {
            string saveas = (saveAsLocation.Split('.')[0]) + ".pdf";
            try
            {
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(saveAsLocation);

                //Save the document in PDF format
                workbook.SaveToFile(saveas, Spire.Xls.FileFormat.PDF);
                System.Diagnostics.Process.Start(saveas);
                Path.GetTempPath();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            InHoaDon();
        }

        private void pnTopper_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
