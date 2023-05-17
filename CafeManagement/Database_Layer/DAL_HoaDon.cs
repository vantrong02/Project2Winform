using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_HoaDon
    {
        DAL_Connection DBHoaDon;
        public DAL_HoaDon()
        {
            DBHoaDon = new DAL_Connection();
        }
        public void ThemHoaDon(string MaKhachHang, string MaNhanVien, double TongHoaDon, double GiamGia)
        {
            string sqlString = "exec sp_ThemHoaDon '" + MaKhachHang + "','" + MaNhanVien + "'," + TongHoaDon + "," + GiamGia;
            DBHoaDon.ExecuteNonQuery(sqlString);
        }

        public DataTable LayDSHoaDon()
        {
            string strSQL = "select * from HOADON";
            DataTable dt = DBHoaDon.Execute(strSQL);
            return dt;
        }

        public double TinhTamTinh(double TongHoaDon, double ThanhTien)
        {
            string sqlString = "select [dbo].tinhTongHoaDon(" + TongHoaDon + "," + ThanhTien + ")";
            DataTable TamTinh = DBHoaDon.Execute(sqlString);
            return double.Parse(TamTinh.Rows[0][0].ToString());
        }

        public double TinhGiamGia(string MaKhachHang, double TamTinh)
        {
            string sqlString = "select [dbo].giamGia('" + MaKhachHang + "'," + TamTinh + ")";
            DataTable dt = DBHoaDon.Execute(sqlString);
            return double.Parse(dt.Rows[0][0].ToString());
        }

        public int LayMaHoaDonHienTai(DateTime ngayGio)
        {
            string sqlString = "select dbo.fn_LayMaHoaDonHienTai ('" + ngayGio + "')";
            //string sqlString = "Select top 1 MaHoaDon from HOADON order by MaHoaDon desc";
            DataTable dt = DBHoaDon.Execute(sqlString);
            int maHoaDon = int.Parse(dt.Rows[0][0].ToString());
            return maHoaDon;
        }



    }
}
