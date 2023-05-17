using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_NhanVien
    {
        DAL_Connection NhanVienDB;
        public DAL_NhanVien()
        {
            NhanVienDB = new DAL_Connection();
        }
        public DataTable getAllNhanVien()
        {
            string strQuery = string.Format("SELECT *FROM vi_NhanVienList");

            DataTable NhanVienTable = NhanVienDB.Execute(strQuery);
            return NhanVienTable;
        }
        public bool ThemNhanVien(string TenNhanVien, string MatKhau, string ChucVu, string NgaySinh, string SDT, double Luong)
        {
            int result = 0;
            string strQuery = string.Format("EXEC sp_ThemNhanVien @TenNhanVien = N'{0}' ," +
                "@MatKhau = '{1}', @ChucVu = N'{2}', @NgaySinh = '{3}', @SDT = '{4}', @Luong = {5}", TenNhanVien, MatKhau, ChucVu, NgaySinh, SDT, Luong);
            result = NhanVienDB.ExecuteNonQueryVer2(strQuery);
            return result > 0;

        }
        public bool SuaNhanVien(string MaNhanVien, string TenNhanVien, string MatKhau, string NgaySinh, string SDT, double Luong, int TrangThai)
        {
            int result = 0;
            string strQuery = string.Format("EXEC sp_CapNhatNhanVien @MaNhanVien = N'{0}', @TenNhanVien = N'{1}',  " +
                "@MatKhau = N'{2}', @NgaySinh = N'{3}', @SDT = N'{4}', @Luong = N'{5}', @TrangThai = {6}", MaNhanVien, TenNhanVien, MatKhau, NgaySinh, SDT, Luong, TrangThai);
            result = NhanVienDB.ExecuteNonQueryVer2(strQuery);
            return result > 0;
        }
        public bool XoaNhanVien(string MaNhanVien)
        {
            int result = 0;
            string strQuery = string.Format("EXEC sp_XoaNhanVien @MaNhanVien = N'{0}'", MaNhanVien);
            result = NhanVienDB.ExecuteNonQueryVer2(strQuery);
            return result > 0;
        }


        public DataTable getNVByID(string MaNhanVien)
        {
            string strQuery = string.Format("SELECT * FROM NHANVIEN Where MaNhanVien = '{0}'", MaNhanVien);
            DataTable NV = NhanVienDB.Execute(strQuery);
            return NV;
        }

        public void SuaPassword(string password, string maNV)
        {
            string strQuery = string.Format("Update Nhanvien set MatKhau = '"+password+"' where MaNhanVien = '"+maNV+"'");
            NhanVienDB.ExecuteNonQuery(strQuery);
        }

        public string GetTenNVTheoMa(string maNV)
        {
            string tenNV = "";
            string sqlQuery = "select TenNhanVien from NHANVIEN where MaNhanVien = N'" + maNV + "'";
            DataTable dt = NhanVienDB.Execute(sqlQuery);
            tenNV = dt.Rows[0][0].ToString();
            return tenNV;
        }


        public DataTable TimKiemNhanVienTheoTen(string TenNV)
        {
            string sqlQuery = "select * from NHANVIEN Where TenNhanVien like '%' + N'"+ TenNV+"' +'%' OR LOWER(TenNhanVien) like '%' + N'"+ TenNV +"'+ '%'";
            DataTable dt = NhanVienDB.Execute(sqlQuery);
            return dt;
        }

        public void CapNhatSoGioLam(DateTime ThoiGianDangNhap, DateTime ThoiGianDangXuat, string MaNhanVien)
        {
            string sqlString = "EXEC sp_TinhSoGioLam '" + ThoiGianDangNhap + "','" + ThoiGianDangXuat + "','" + MaNhanVien + "'";
            NhanVienDB.ExecuteNonQuery(sqlString);

        }

        public DataTable getNhanVien()
        {
            string strQuery = string.Format("SELECT MaNhanVien, TenNhanVien FROM NHANVIEN WHERE ChucVu = N'Nhân viên' AND TrangThai = 1");
            DataTable TableNhanVien = NhanVienDB.Execute(strQuery);
            return TableNhanVien;

        }
        public DataTable NhanVienXuatSacTheoThang(int month)
        {
            string strQuery = string.Format("EXEC sp_ThongKeNhanVienTheoThang @month = {0}", month);
            DataTable dt = NhanVienDB.Execute(strQuery);
            return dt;

        }
        public DataTable NhanVienXuatSacTheoNam(int year)
        {
            string strQuery = string.Format("EXEC sp_ThongKeNhanVienTheoNam @year = {0}", year);
            DataTable dt = NhanVienDB.Execute(strQuery);
            return dt;

        }
    }
}
