using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_KhachHang
    {
        DAL_Connection DBKhachHang;
        public DAL_KhachHang()
        {
            DBKhachHang = new DAL_Connection();
        }

        public DataTable getAllKhachHang()
        {
            string strQuery = string.Format("SELECT * FROM vi_GetInfoKhachHang");
            DataTable KhachHang = DBKhachHang.Execute(strQuery);
            return KhachHang;
        }

        public DataTable GetInFoKhachHang()
        {
            string sqlString = "Select * from vi_GetInFoKhachHang";
            DataTable dt = DBKhachHang.Execute(sqlString);
            return dt;
        }

        public void CapNhatDiemTichLuy(string MaKhachHang, double ThanhTien, int DungDiem)
        {
            string sqlString = "exec sp_CapNhatDiemTichLuy '" + MaKhachHang + "'," + ThanhTien + "," + DungDiem ;
            DBKhachHang.ExecuteNonQuery(sqlString);
        }

        public void CapNhatTongChiTieu(string MaKhachHang, double TienPhaiTra)
        {
            string sqlString = "update KHACHHANGTHANTHIET set TongChiTieu = TongChiTieu + "+ TienPhaiTra +" where SDT = '"+ MaKhachHang +"'";
            DBKhachHang.ExecuteNonQuery(sqlString);
        }

        public void DangKyKhachHang(string SDT, string TenKhachHang, double SoTienPhaiTra)
        {
            string sqlString = "INSERT INTO KHACHHANGTHANTHIET(SDT, TenKhachHang, DiemTichLuy, TongChiTieu) VALUES('"+ SDT +"', '"+ TenKhachHang +"', "+SoTienPhaiTra/20000 +", "+ SoTienPhaiTra +")";
            DBKhachHang.ExecuteNonQuery(sqlString);
        }

        public bool XoaKhachHang(string MaKhachHang)
        {
            int result = 0;
            string strQuery = string.Format("EXEC sp_XoaKhachHang @SDT = N'{0}'", MaKhachHang);
            result = DBKhachHang.ExecuteNonQueryVer2(strQuery);
            if (result > 0)

                return true;

            else
                return false;
        }
        public bool SuaKhachHang(string MaKhachHang, string TenKhachHang)
        {
            int result = 0;
            string strQuery = string.Format("EXEC sp_CapNhatKhachHang @MaKhachHang = N'{0}', @TenKhachHang = N'{1}'", MaKhachHang, TenKhachHang);
            result = DBKhachHang.ExecuteNonQueryVer2(strQuery);
            return result > 0;
        }
        public DataTable TimKiemKhachHangTheoTen(string TenKhachHang)
        {
            string strQuery = string.Format("EXEC sp_TimKiemKhachHangTheoTen @TenKhachHang = N'{0}'", TenKhachHang);
            DataTable KhachHangTheoTen = DBKhachHang.Execute(strQuery);
            return KhachHangTheoTen;
        }
        public DataTable TimKiemKhachHangTheoMa(string MaKhachHang)
        {
            string strQuery = "EXEC sp_TimKiemKhachHangTheoMa '"+ MaKhachHang +"'";
            DataTable KhachHangTheoMa = DBKhachHang.Execute(strQuery);
            return KhachHangTheoMa;
        }

        public DataTable XepHangKhachHang(string Query)
        {

            DataTable KhachHangTheoMa = DBKhachHang.Execute(Query);
            return KhachHangTheoMa;
        }

        public string GetTenKH(string MaKhachHang)
        {
            string strQuery = "select TenKhachHang from KHACHHANGTHANTHIET where SDT = '" + MaKhachHang + "'";
            DataTable KhachHangTheoMa = DBKhachHang.Execute(strQuery);
            string tenKH = KhachHangTheoMa.Rows[0][0].ToString();
            return tenKH;
        }
    }
}
