using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_SaleOrder
    {
        DAL_Connection DBSaleOrder;
        public DAL_SaleOrder()
        {
            DBSaleOrder = new DAL_Connection();
        }
        
        public DataTable GetMonTrongMoiDanhMuc(string MaDanhMuc)
        {
            string sqlString = "select * from [dbo].cacMonTrongDanhMuc( '"+ MaDanhMuc+"')";
            DataTable dt = DBSaleOrder.Execute(sqlString);
            return dt;
        }


        public int LayMaHoaDonHienTai(DateTime ngayGio)
        {
            string sqlString = "select dbo.fn_LayMaHoaDonHienTai ('" + ngayGio + "')";
            //string sqlString = "Select top 1 MaHoaDon from HOADON order by MaHoaDon desc";
            DataTable dt = DBSaleOrder.Execute(sqlString);
            int maHoaDon = int.Parse(dt.Rows[0][0].ToString());
            return maHoaDon;
        }


    }
}
