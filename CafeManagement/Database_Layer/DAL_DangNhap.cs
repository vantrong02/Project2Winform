using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_DangNhap
    {
        DAL_Connection db;
        public DAL_DangNhap()
        {
            db = new DAL_Connection();
        }

        public DataTable KiemTraTaiKhoanHopLe(string maNhanVien, string matKhau)
        {
            string sqlString = "select * from fn_GetMotTaiKhoan('" + maNhanVien + "', '" + matKhau + "')";
            DataTable dt = db.Execute(sqlString);
            return dt;
        }

    }
}
