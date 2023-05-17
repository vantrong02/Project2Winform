using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL

{
    public class DAL_ChiTietHoaDon
    {
        DAL_Connection DBChiTietHoaDon;
        public DAL_ChiTietHoaDon()
        {
            DBChiTietHoaDon = new DAL_Connection();
        }

        public DataTable LayChiTietMotHoaDon(int maHoaDon, DateTime ngayGio)
        {
            string strSQL = "SELECT * FROM fn_XuatChiTietMotHoaDon (" + maHoaDon + ", '" + ngayGio + "')";
            DataTable dt = DBChiTietHoaDon.Execute(strSQL);
            return dt;
        }

        public void ThemChiTietHoaDon(string MaThucUong, int SoLuong)
        {
            string sqlString = " exec sp_ThemChiTietHoaDon '" + MaThucUong + "', " + SoLuong;
            DBChiTietHoaDon.ExecuteNonQuery(sqlString);
        }

        public double TinhThanhTien(double DonGia, int SoLuong)
        {
            string sqlString = "select [dbo].tinhThanhTien(" + DonGia + "," + SoLuong + ")";
            DataTable ThanhTien = DBChiTietHoaDon.Execute(sqlString);
            return double.Parse(ThanhTien.Rows[0][0].ToString());
        }

    }
}
