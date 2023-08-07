using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stanford_BookStore_Webform.Models
{
    public class NguoiDungBusiness
    {
        /// <summary>
        /// Lấy thông tin tài khoản theo tên đăng nhập
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        public NguoiDung LayThongTinNguoiDung(string tenDangNhap)
        {
            NguoiDung objUser = null;
            string strSQL = "Select * from NguoiDung where TenDangNhap = @TenDangNhap";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@TenDangNhap", System.Data.SqlDbType.VarChar, 50);
            pars[0].Value = tenDangNhap;

            DataTable dtUser = DataProvider.LayDanhSach(strSQL, pars);

            if(dtUser.Rows.Count > 0)
            {
                objUser = new NguoiDung();

                objUser.Id = int.Parse("" + dtUser.Rows[0]["Id"]);
                objUser.TenDangNhap = "" + dtUser.Rows[0]["TenDangNhap"];
                objUser.MatKhau = "" + dtUser.Rows[0]["MatKhau"];
                objUser.HoTen = "" + dtUser.Rows[0]["HoTen"];
            }

            return objUser;
        }
    }
}