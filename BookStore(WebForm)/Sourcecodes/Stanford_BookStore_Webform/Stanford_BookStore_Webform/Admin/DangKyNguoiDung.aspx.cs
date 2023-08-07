using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stanford_BookStore_Webform.Admin
{
    public partial class DangKyNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtDienThoai_ServerValidation(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length >= 10);
        }
    }
}