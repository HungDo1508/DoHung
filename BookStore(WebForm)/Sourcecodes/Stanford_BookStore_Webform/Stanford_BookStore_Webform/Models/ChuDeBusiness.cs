using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Stanford_BookStore_Webform.Models
{
    public class ChuDeBusiness
    {
        /// <summary>
        /// Lấy danh sách chủ đề
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaChuDe, TenChuDe from ChuDe";

            return DataProvider.LayDanhSach(strSQL);
        }
    }
}