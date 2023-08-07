using Stanford_BookStore_Webform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stanford_BookStore_Webform
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Xử lý đăng nhập và lưu thông tin đăng nhập nếu thành công
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = "", matKhau = "";

            lblThongBao.Text = "";

            tenDangNhap = txtTenDangNhap.Text.Trim();
            matKhau = txtMatKhau.Text;

            NguoiDungBusiness nguoiDungBusiness = new NguoiDungBusiness();

            NguoiDung objUser = nguoiDungBusiness.LayThongTinNguoiDung(tenDangNhap);

            if(objUser != null)
            {
                if(objUser.MatKhau == matKhau)
                {
                    //Lưu session
                    Session["UserOnline"] = tenDangNhap;
                    Response.Redirect("~/Admin/BookList.aspx");
                }    
                else
                {
                    lblThongBao.Text = "Mật khẩu nhập không chính xác";
                    txtMatKhau.Focus();
                }    
            } 
            else
            {
                lblThongBao.Text = "Tài khoản không tồn tại. Bạn vui lòng kiểm tra lại";
                txtTenDangNhap.Focus();
            }    
        }
    }
}