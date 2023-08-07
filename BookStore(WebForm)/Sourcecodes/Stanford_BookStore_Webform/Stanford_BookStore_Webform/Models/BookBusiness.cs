using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stanford_BookStore_Webform.Models
{
    public class BookBusiness
    {
        /// <summary>
        /// Khai báo 1 danh sách
        /// </summary>
        private List<BookInfo> lstBooks = new List<BookInfo>();

        /// <summary>
        /// Hàm tìm kiếm thông tin sách
        /// </summary>
        /// <param name="tuKhoa">Từ khóa</param>
        /// <param name="maChuDe">Mã chủ đề</param>
        /// <returns>Kết quả thông tin sách phù hợp với điều kiện tìm kiếm</returns>
        public DataTable TimKiemSach(string tuKhoa, string maChuDe)
        {
            string strSQL = "Select Id, TenSach, MoTa, AnhSach, GiaSach, TacGia, NgayTao, MaChuDe from Sach where 1=1";

            if(!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (TenSach like N'%{0}%' " +
                    "OR TacGia like N'%{0}%' MoTa like N'%{0}%')", tuKhoa);
            }

            if (!string.IsNullOrEmpty(maChuDe))
            {
                strSQL += string.Format(" AND MaChuDe = '{0}'", maChuDe);
            }

            return DataProvider.LayDanhSach(strSQL);
        }

        /// <summary>
        /// Hàm lấy danh sách sách trong hệ thống
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            string strSQL = "Select Id, TenSach, MoTa, AnhSach, GiaSach, TacGia, NgayTao, MaChuDe from Sach";
            return DataProvider.LayDanhSach(strSQL);
        }

        
        /// <summary>
        /// Thêm mới thông tin sách
        /// </summary>
        /// <param name="objBook">Đối tượng sách cần thêm</param>
        /// <returns>true nếu thực hiện thành công, false nếu thất bại</returns>
        public bool ThemMoi(BookInfo objBook)
        {
            if(objBook != null)
            {
                string strInsert = "Insert into Sach(TenSach, MoTa, AnhSach, GiaSach, TacGia, NgayTao, NgayCapNhat, NgayXuatBan, MaChuDe) values(@TenSach, @MoTa, @AnhSach, @GiaSach, @TacGia, @NgayTao, @NgayCapNhat, @NgayXuatBan, @MaChuDe)";

                //Khai báo mảng chứa các tham số
                SqlParameter[] pars = new SqlParameter[9];

                pars[0] = new SqlParameter("@TenSach", SqlDbType.NVarChar, 250);
                pars[0].Value = objBook.TenSach;

                pars[1] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
                pars[1].Value = objBook.MoTa;

                pars[2] = new SqlParameter("@AnhSach", SqlDbType.VarChar, 50);
                pars[2].Value = objBook.AnhSach;

                pars[3] = new SqlParameter("@GiaSach", SqlDbType.Float);
                pars[3].Value = objBook.GiaSach;

                pars[4] = new SqlParameter("@TacGia", SqlDbType.NVarChar, 50);
                pars[4].Value = objBook.TacGia;

                pars[5] = new SqlParameter("@NgayTao", SqlDbType.DateTime);
                pars[5].Value = objBook.NgayTao;

                pars[6] = new SqlParameter("@NgayCapNhat", SqlDbType.DateTime);
                pars[6].Value = objBook.NgayCapNhat;

                pars[7] = new SqlParameter("@NgayXuatBan", SqlDbType.DateTime);
                pars[7].Value = objBook.NgayXuatBan;


                pars[8] = new SqlParameter("@MaChuDe", SqlDbType.VarChar, 10);
                pars[8].Value = objBook.MaChuDe;

                return DataProvider.ThucHien(strInsert, pars);
            }

            return false;
        }

        /// <summary>
        /// Hàm hiển thị thông tin chi tiết của sách
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookInfo LayChiTietTheoMa(int bookId)
        {
            //Khai báo 1 đối tượng
            BookInfo objBook = null;

            string strSQL = "Select * from Sach where Id = " + bookId;

            DataTable dtSach = DataProvider.LayDanhSach(strSQL);

            if(dtSach!= null && dtSach.Rows.Count > 0)
            {
                objBook = new BookInfo();

                //Gán giá trị cho các thuộc tính
                objBook.Id = bookId;
                objBook.TenSach = "" + dtSach.Rows[0]["TenSach"];
                objBook.MoTa = "" + dtSach.Rows[0]["MoTa"];
                objBook.AnhSach = "" + dtSach.Rows[0]["AnhSach"];
                objBook.TacGia = "" + dtSach.Rows[0]["TacGia"];
                float giaSach = 0;
                float.TryParse("" + dtSach.Rows[0]["GiaSach"], out giaSach);
                objBook.GiaSach = giaSach;

                DateTime ngayTao, ngayCapNhat, ngayXuatBan;
                DateTime.TryParse("" + dtSach.Rows[0]["NgayTao"], out ngayTao);
                DateTime.TryParse("" + dtSach.Rows[0]["NgayCapNhat"], out ngayCapNhat);
                DateTime.TryParse("" + dtSach.Rows[0]["NgayXuatBan"], out ngayXuatBan);

                objBook.NgayTao = ngayTao;
                objBook.NgayCapNhat = ngayCapNhat;
                objBook.NgayXuatBan = ngayXuatBan;
            }    

            return objBook;
        }

        /// <summary>
        /// Hàm cập nhật thông tin
        /// </summary>
        /// <param name="objBook"></param>
        /// <returns></returns>
        public bool CapNhat(BookInfo objBook)
        {
            string strUpdate = "Update Sach set TenSach=@TenSach, MoTa=@MoTa, AnhSach=@AnhSach, GiaSach=@GiaSach, TacGia=@TacGia,NgayCapNhat=@NgayCapNhat,NgayXuatBan=@NgayXuatBan,MaChuDe=@MaChuDe where Id=@Id";

            //Khai báo mảng chứa các tham số
            SqlParameter[] pars = new SqlParameter[9];

            pars[0] = new SqlParameter("@TenSach", SqlDbType.NVarChar, 250);
            pars[0].Value = objBook.TenSach;

            pars[1] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 1000);
            pars[1].Value = objBook.MoTa;

            pars[2] = new SqlParameter("@AnhSach", SqlDbType.VarChar, 50);
            pars[2].Value = objBook.AnhSach;

            pars[3] = new SqlParameter("@GiaSach", SqlDbType.Float);
            pars[3].Value = objBook.GiaSach;

            pars[4] = new SqlParameter("@TacGia", SqlDbType.NVarChar, 50);
            pars[4].Value = objBook.TacGia;

            pars[5] = new SqlParameter("@NgayCapNhat", SqlDbType.DateTime);
            pars[5].Value = objBook.NgayCapNhat;

            pars[6] = new SqlParameter("@NgayXuatBan", SqlDbType.DateTime);
            pars[6].Value = objBook.NgayXuatBan;


            pars[7] = new SqlParameter("@MaChuDe", SqlDbType.VarChar, 10);
            pars[7].Value = objBook.MaChuDe;

            pars[8] = new SqlParameter("@Id", SqlDbType.Int);
            pars[8].Value = objBook.Id;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        /// <summary>
        /// Hàm thực hiện xóa thông tin sách
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool Xoa(int bookId)
        {
            string strDelete = "Delete from Sach where Id=@Id";

            //Khai báo mảng chứa các tham số
            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@Id", SqlDbType.Int);
            pars[0].Value = bookId;

            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}