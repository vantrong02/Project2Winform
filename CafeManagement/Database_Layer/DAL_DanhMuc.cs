using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_DanhMuc
    {
        DAL_Connection DanhMucDB;
        public DAL_DanhMuc()
        {
            DanhMucDB = new DAL_Connection();
        }

        public DataTable GetDanhMuc()
        {
            string sqlString = "select * from DANHMUC";
            DataTable dt = DanhMucDB.Execute(sqlString);
            return dt;
        }

        
        public void CapNhatDanhMuc(string MaDanhMuc, string TenDanhMuc)
        {
            string sqlString = "exec sp_CapNhatDanhMuc '" + MaDanhMuc + "','" + TenDanhMuc + "'";
            DanhMucDB.ExecuteNonQuery(sqlString);
        }


    }
}
