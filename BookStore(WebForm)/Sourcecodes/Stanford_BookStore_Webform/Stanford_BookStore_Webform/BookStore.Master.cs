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
    public partial class BookStore : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HienThiChuDeSach();
            }    
        }

        /// <summary>
        /// Hiển thị chủ đề sách
        /// </summary>
        private void HienThiChuDeSach()
        {
            ChuDeBusiness chuDeBusiness = new ChuDeBusiness();

            DataTable dtChuDe = chuDeBusiness.LayDanhSach();

            rptChuDe.DataSource = dtChuDe;
            rptChuDe.DataBind();
        }
    }
}