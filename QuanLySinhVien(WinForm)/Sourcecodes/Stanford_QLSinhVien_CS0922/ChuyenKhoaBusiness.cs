using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Stanford_QLSinhVien_CS0922
{
   public class ChuyenKhoaBusiness
    {
        /// <summary>
        /// Hàm lấy danh sách khoa
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaKhoa, TenKhoa from ChuyenKhoa";

            return DataProvider.LayDanhSach(strSQL);
        }
    }
}
