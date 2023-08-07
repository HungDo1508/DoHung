using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Stanford_QLSinhVien_CS0922
{
    public class NguoiDungBusiness
    {
        /// <summary>
        /// Hàm lấy thông tin người dùng theo tên đăng nhập
        /// Author      Date        Comments
        /// DangBQ      14/12/22    Tạo mới
        /// </summary>
        /// <param name="tenDN">Tên đăng nhập cần lấy thông tin chi tiết</param>
        /// <returns>Đối tượng người dùng chứa thông tin chi tiết</returns>
        public NguoiDung LayThongTinTheoTenDangNhap(string tenDN)
        {
            NguoiDung objUser = null;
            string strSQL = "Select Id, HoTen, TenDangNhap, MatKhau from NguoiDung where TenDangNhap='" + tenDN + "'";

            DataTable dtUser = DataProvider.LayDanhSach(strSQL);

            if(dtUser.Rows.Count > 0)
            {
                objUser = new NguoiDung();

                //Gán giá trị
                objUser.Id = int.Parse("" + dtUser.Rows[0]["Id"]);
                objUser.TenDangNhap = "" + dtUser.Rows[0]["TenDangNhap"];
                objUser.HoTen = "" + dtUser.Rows[0]["HoTen"];
                objUser.MatKhau = "" + dtUser.Rows[0]["MatKhau"];
            }

            return objUser;
        }
    }
}
