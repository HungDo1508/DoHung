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
    public partial class BookAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HienThiChuDeSach();

                HienThiThongTinChiTiet();
            }
        }

        /// <summary>
        /// Hiển thị chủ đề sách lên dropdownlist
        /// </summary>
        private void HienThiChuDeSach()
        {
            ChuDeBusiness chuDeBusiness = new ChuDeBusiness();

            DataTable dtChuDe = chuDeBusiness.LayDanhSach();

            ddlChuDe.DataTextField = "TenChuDe";
            ddlChuDe.DataValueField = "MaChuDe";
            ddlChuDe.DataSource = dtChuDe;
            ddlChuDe.DataBind();
        }

        /// <summary>
        /// Hàm hiển thị thông tin chi tiết sách
        /// Author      Date        Comments
        /// DangBQ      19/4/23     Tạo mới
        /// </summary>
        private void HienThiThongTinChiTiet()
        {
            //Lấy thông tin từ url
            int bookId = 0;
            int.TryParse("" + Request["id"], out bookId);

            if(bookId > 0)
            {
                //Lấy đối tượng sách
                BookInfo objBook = DataProvider.BookBus.LayChiTietTheoMa(bookId);

                if(objBook != null)
                {
                    txtTenSach.Text = objBook.TenSach;
                    txtMoTa.Text = objBook.MoTa;
                    txtTacGia.Text = objBook.TacGia;
                    txtGiaSach.Text = "" + objBook.GiaSach;
                    imgAnhDaiDien.ImageUrl = "~/Content/images/" + objBook.AnhSach;
                    ddlChuDe.SelectedValue = "" + objBook.MaChuDe;
                    hImage.Value = "" + objBook.AnhSach;
                }    
            }    
        }

        //Random rand = new Random();

        /// <summary>
        /// Hàm xử lý thông tin thêm mới hoặc cập nhật sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCapNhat_Click(object sender, EventArgs e)
        {
            int bookId = 0;

            //Khai báo 1 đối tượng
            BookInfo objBook = new BookInfo();

            //objBook.Id = rand.Next(6, 100);

            //Lấy giá trị trên giao diện gán cho thuộc tính
            objBook.TenSach = txtTenSach.Text.Trim();
            objBook.MoTa = txtMoTa.Text;
            objBook.TacGia = txtTacGia.Text.Trim();

            double giaSach = 0;
            double.TryParse(txtGiaSach.Text, out giaSach);

            //Gán cho thuộc tính
            objBook.GiaSach = giaSach;
            objBook.NgayTao = DateTime.Now;
            objBook.NgayXuatBan = DateTime.Now;
            objBook.MaChuDe = "" + ddlChuDe.SelectedValue;

            //Xử lý upload ảnh
            if(fUpload.HasFile)
            {
                fUpload.SaveAs(Server.MapPath("~/Content/images/" + fUpload.FileName));
                objBook.AnhSach = fUpload.FileName;
            } 
            else//Nếu không chọn ảnh thì lấy từ hidden field ra
            {
                objBook.AnhSach = hImage.Value;
            }    
            
            bool ketQua = false;

            //TH sửa
            if (!string.IsNullOrEmpty("" + Request["id"]))
            {
                objBook.NgayCapNhat = DateTime.Now;

                int.TryParse("" + Request["id"], out bookId);
                objBook.Id = bookId;

                ketQua = DataProvider.BookBus.CapNhat(objBook);
            }
            else
            {
                objBook.NgayCapNhat = DateTime.Now;
                ketQua = DataProvider.BookBus.ThemMoi(objBook);
            }

            if(ketQua)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ThongBao", "<script>alert('Cập nhật thông tin sách thành công');</script>");
            }    
        }
    }
}