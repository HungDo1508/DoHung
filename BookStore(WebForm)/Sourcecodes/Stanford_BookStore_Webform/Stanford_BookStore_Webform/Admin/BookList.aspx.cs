using Stanford_BookStore_Webform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stanford_BookStore_Webform.Admin
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Chỉ gọi lần đầu khi load trang
            if(!IsPostBack)
            {
                HienThiDanhSachSach();
            }    
        }

        /// <summary>
        /// Danh sách thông tin sách trong hệ thống
        /// </summary>
        private void HienThiDanhSachSach()
        {
            //Lấy danh sách
            BookBusiness bus = new BookBusiness();

            DataTable dtSach = bus.LayDanhSach();

            //Hiển thị lên gridview
            gridSach.DataSource = dtSach;
            gridSach.DataBind();
        }

        protected void gridSach_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Sua")
            {
                string bookId = "" + e.CommandArgument;

                //Di chuyển sang trang sửa
                Response.Redirect("~/Admin/BookAdd.aspx?id=" +  bookId);
            }    

            if(e.CommandName == "Xoa")
            {
                string strBookId = "" + e.CommandArgument;

                int bookId = 0;
                int.TryParse(strBookId, out bookId);

                //Thực hiện xóa
                bool ketQua = false;
                ketQua = DataProvider.BookBus.Xoa(bookId);

                if(ketQua)
                {
                    HienThiDanhSachSach();
                }    
            }    
        }
    }
}