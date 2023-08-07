using Stanford_BookStore_Webform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stanford_BookStore_Webform
{
    public partial class TrangChu2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDanhSach();
            }
        }

        /// <summary>
        /// Hiển thị danh sách sách lên giao diện
        /// </summary>
        private void HienThiDanhSach()
        {
            BookBusiness bus = new BookBusiness();

            //Lấy danh sách
            DataTable dtSach = bus.LayDanhSach();

            dlSach.DataSource = dtSach;
            dlSach.DataBind();
        }

        protected void dlSach_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
            {
                return;
            }

            Literal lblCanChinh = (Literal)e.Item.FindControl("lblCanChinh");
            if (lblCanChinh != null)
            {
                if (e.Item.ItemIndex % 2 == 0)
                {
                    lblCanChinh.Text = "<div class=\"cleaner_with_width\">&nbsp;</div>";
                }
                else
                {
                    lblCanChinh.Text = "<div class=\"cleaner_with_height\">&nbsp;</div>";
                }
            }
        }
    }
}