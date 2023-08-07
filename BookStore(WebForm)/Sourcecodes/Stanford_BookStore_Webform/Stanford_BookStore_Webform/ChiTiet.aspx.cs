using Stanford_BookStore_Webform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stanford_BookStore_Webform
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HienThiChiTiet();
            }    
        }

        /// <summary>
        /// Hàm hiển thị thông tin chi tiết sách
        /// </summary>
        private void HienThiChiTiet()
        {
            int bookId = 0;

            int.TryParse("" + Request["ma"], out bookId);

            if (bookId > 0)
            {
                BookBusiness bookBusiness = new BookBusiness();

                BookInfo objBook = bookBusiness.LayChiTietTheoMa(bookId);

                if (objBook != null)
                {
                    lblTenSach.Text = objBook.TenSach;
                    lblMoTa.Text = objBook.MoTa;
                    imgAnhSach.ImageUrl = "~/Content/images/" + objBook.AnhSach;
                    lblTacGia.Text = objBook.TacGia;
                    lblGiaSach.Text = objBook.GiaSach.ToString("###,###");
                }
            }
        }
    }
}