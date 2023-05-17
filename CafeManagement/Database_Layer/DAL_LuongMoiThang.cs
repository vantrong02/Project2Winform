using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_LuongMoiThang
    {
        DAL_Connection DBLuong;
        public DAL_LuongMoiThang()
        {
            DBLuong = new DAL_Connection();
        }

        public void TinhLuongNhanVien(string MaNhanVien, int luong, int trangthai)
        {
            string strQuery = string.Format("INSERT INTO LUONGMOITHANG VALUES (N'{0}',{1},{2},{3},{4})", MaNhanVien, DateTime.Now.Month, DateTime.Now.Year, luong, trangthai);
            DBLuong.ExecuteNonQuery(strQuery);
        }
        public DataTable getAllLuong(string MaNhanVien)
        {
            string strQuery = string.Format("SELECT *FROM LuongMoiThang Where MaNhanVien = '{0}'", MaNhanVien);

            DataTable LuongNhanVienTable = DBLuong.Execute(strQuery);
            return LuongNhanVienTable;
        }
        public DataTable getLuongTheoTrangThai(string MaNhanVien, int status)
        {
            string strQuery = string.Format("SELECT *FROM LuongMoiThang Where MaNhanVien = '{0}' AND TinhTrang = {1}", MaNhanVien, status);
            DataTable LuongNhanVienTable = DBLuong.Execute(strQuery);
            return LuongNhanVienTable;
        }
        public void CapNhatTrangThaiLuong(string MaNhanVien, int thang, int nam, int salary)
        {
            string strQuery = string.Format("UPDATE LUONGMOITHANG SET TinhTrang = 1 WHERE MaNhanVien = '{0}' AND Thang = {1} AND Nam = {2} AND Luong = {3} AND TinhTrang = 0", MaNhanVien, thang, nam, salary);
            DBLuong.ExecuteNonQuery(strQuery);
        }
    }
}
