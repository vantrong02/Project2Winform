using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_DoanhThu
    {
        DAL_Connection DoanhThuDB;
        public DAL_DoanhThu()
        {
            DoanhThuDB = new DAL_Connection();
        }
        public DataTable getDoanhThuHomNay()
        {
            string strQuery = string.Format("EXEC sp_XemDoanhThuHomNay");
            DataTable TableDoanhThuHomNay = DoanhThuDB.Execute(strQuery);
            return TableDoanhThuHomNay;
        }
        public DataTable getDoanhThuTheoNgay()
        {
            string strQuery = string.Format("EXEC sp_XemDoanhThuTheoNgay");
            DataTable TableDoanhThuTheoNgay = DoanhThuDB.Execute(strQuery);
            return TableDoanhThuTheoNgay;
        }
        public DataTable getDoanhThuTheoThang()
        {
            string strQuery = string.Format("EXEC sp_XemDoanhThuTheoThang");
            DataTable TableDoanhThuTheoThang = DoanhThuDB.Execute(strQuery);
            return TableDoanhThuTheoThang;
        }
        public DataTable getDoanhThuTheoNam()
        {
            string strQuery = string.Format("EXEC sp_XemDoanhThuTheoNam");
            DataTable TableDoanhThuTheoNam = DoanhThuDB.Execute(strQuery);
            return TableDoanhThuTheoNam;
        }
        public DataTable getDoanhThuTuyChon(string begin, string end)
        {
            string strQuery = string.Format("EXEC sp_XemDoanhThuTuyChon @begin_date = '{0}', @end_date = '{1}'", begin, end);
            DataTable TableDoanhThuTuyChon = DoanhThuDB.Execute(strQuery);
            return TableDoanhThuTuyChon;
        }
        public DataTable loadSanPhamTheoDoanhThu(string begin, string end)
        {
            string strQuery = string.Format("EXEC sp_LoadSanPhamTheoDoanhThu @datebegin = '{0}', @dateend = '{1}'", begin, end);
            DataTable TableSanPham = DoanhThuDB.Execute(strQuery);
            return TableSanPham;
        }

        
    }
}
