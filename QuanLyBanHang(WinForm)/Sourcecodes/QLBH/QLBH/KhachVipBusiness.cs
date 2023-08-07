using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLBH
{
   public class KhachVipBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaLoai, TenLoai from LoaiKhachHang";

            return DataProvider.LayDanhSach(strSQL);
        }
    }
}
