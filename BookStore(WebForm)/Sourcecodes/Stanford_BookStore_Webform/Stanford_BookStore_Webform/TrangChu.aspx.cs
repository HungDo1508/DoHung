using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Stanford_BookStore_Webform.Models;

namespace Stanford_BookStore_Webform
{
    public partial class TrangChu : System.Web.UI.Page
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
            string ma = "";

            if(!string.IsNullOrEmpty("" + Request["ma"]))
            {
                ma = "" + Request["ma"];
            }    
            BookBusiness bus = new BookBusiness();

            //Lấy danh sách
            DataTable dtSach = bus.TimKiemSach("", ma);

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