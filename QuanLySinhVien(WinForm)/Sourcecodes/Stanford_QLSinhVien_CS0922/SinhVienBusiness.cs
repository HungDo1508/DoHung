using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Stanford_QLSinhVien_CS0922
{
    public class SinhVienBusiness
    {
        /// <summary>
        /// Khai báo 1 biến để chứa danh sách sinh viên
        /// </summary>
        private List<SinhVien> lstSinhVien = new List<SinhVien>();

        /// <summary>
        /// Hàm lấy danh sách sinh viên
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaSV, HoTen, DienThoai, Email, DiaChi, MaKhoa from SinhVien";
            
            return DataProvider.LayDanhSach(strSQL);
        }

        /// <summary>
        /// Hàm tìm kiếm thông tin sinh viên theo nhiều tiêu chí
        /// Author      Date        Comments
        /// DangBQ      23/11/22    Tạo mới
        /// </summary>
        /// <param name="tuKhoa">Từ khóa cần tìm kiếm</param>
        /// <param name="maKhoa">Mã khoa</param>
        /// <returns>Danh sách thỏa mãn điều kiện tìm kiếm</returns>
        public DataTable TimKiemSinhVien(string tuKhoa, string maKhoa)
        {
            string strSQL = "Select MaSV, HoTen, DienThoai, Email, DiaChi, MaKhoa from SinhVien where 1=1";

            if(!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (MaSV='{0}' OR HoTen like N'%{0}%' OR DienThoai like '%{0}%' OR Email like '%{0}%')", tuKhoa);
            }

            if(!string.IsNullOrEmpty(maKhoa))
            {
                strSQL += string.Format(" AND MaKhoa='{0}'", maKhoa);
            }

            return DataProvider.LayDanhSach(strSQL);
        }


        /// <summary>
        /// Hàm lấy thông tin chi tiết của sinh viên theo mã
        /// </summary>
        /// <param name="maSV">Mã sinh viên cần lấy thông tin</param>
        /// <returns>Đối tượng sinh viên lấy được theo mã</returns>
        public SinhVien LayChiTietTheoMa(string maSV)
        {
            //Khai báo biến
            SinhVien objSinhVien = null;

            string strSQL = "Select * from SinhVien where MaSV ='" + maSV + "'";

            DataTable dtSV = DataProvider.LayDanhSach(strSQL);

            if(dtSV != null && dtSV.Rows.Count > 0)
            {
                objSinhVien = new SinhVien();

                objSinhVien.MaSV = "" + dtSV.Rows[0]["MaSV"];
                objSinhVien.HoTen = "" + dtSV.Rows[0]["HoTen"];
                objSinhVien.DienThoai = "" + dtSV.Rows[0]["DienThoai"];
                objSinhVien.Email = "" + dtSV.Rows[0]["Email"];
                int gioiTinh = 0;
                int.TryParse("" + dtSV.Rows[0]["GioiTinh"], out gioiTinh);
                objSinhVien.GioiTinh = gioiTinh;
                objSinhVien.DiaChi = "" + dtSV.Rows[0]["DiaChi"];

                DateTime ngaySinh;
                DateTime.TryParse("" + dtSV.Rows[0]["NgaySinh"], out ngaySinh);
                objSinhVien.NgaySinh = ngaySinh;
                objSinhVien.MaKhoa = "" + dtSV.Rows[0]["MaKhoa"];
            }    

            return objSinhVien;
        }


        /// <summary>
        /// Hàm thêm mới thông tin sinh viên vào hệ thống
        /// </summary>
        /// <param name="objSV">Đối tượng sv cần thêm</param>
        /// <returns>True nếu thêm thành công, False nếu thất bại</returns>
        public bool ThemMoi(SinhVien objSV)
        {
            string strInsert = "Insert into SinhVien(MaSV, HoTen, GioiTinh, NgaySinh, DienThoai, Email, DiaChi, MaKhoa) values(@MaSV, @HoTen, @GioiTinh, @NgaySinh, @DienThoai, @Email, @DiaChi, @MaKhoa)";

            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaSV", SqlDbType.VarChar, 10);
            pars[0].Value = objSV.MaSV;

            pars[1] = new SqlParameter("@HoTen", SqlDbType.NVarChar, 30);
            pars[1].Value = objSV.HoTen;

            pars[2] = new SqlParameter("@GioiTinh", SqlDbType.Int);
            pars[2].Value = objSV.GioiTinh;

            pars[3] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            pars[3].Value = objSV.NgaySinh;

            pars[4] = new SqlParameter("@DienThoai", SqlDbType.VarChar, 20);
            pars[4].Value = objSV.DienThoai;

            pars[5] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            pars[5].Value = objSV.Email;

            pars[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
            pars[6].Value = objSV.DiaChi;

            pars[7] = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
            pars[7].Value = objSV.MaKhoa;

            return DataProvider.ThucHien(strInsert, pars);
        }
        /// <summary>
        /// Hàm cập nhật thông tin mới cho sinh viên
        /// </summary>
        /// <param name="objSV">Đối tượng sinh viên chứa thông tin cần cập nhật</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        public bool CapNhat(SinhVien objSV)
        {
            string strUpdate = "Update SinhVien set HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, DienThoai=@DienThoai, Email=@Email, DiaChi=@DiaChi, MaKhoa=@MaKhoa where MaSV=@MaSV";

            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@HoTen", SqlDbType.NVarChar, 30);
            pars[0].Value = objSV.HoTen;

            pars[1] = new SqlParameter("@GioiTinh", SqlDbType.Int);
            pars[1].Value = objSV.GioiTinh;

            pars[2] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            pars[2].Value = objSV.NgaySinh;

            pars[3] = new SqlParameter("@DienThoai", SqlDbType.VarChar, 20);
            pars[3].Value = objSV.DienThoai;

            pars[4] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            pars[4].Value = objSV.Email;

            pars[5] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
            pars[5].Value = objSV.DiaChi;

            pars[6] = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
            pars[6].Value = objSV.MaKhoa;

            pars[7] = new SqlParameter("@MaSV", SqlDbType.VarChar, 10);
            pars[7].Value = objSV.MaSV;

            return DataProvider.ThucHien(strUpdate, pars);
        }

        /// <summary>
        /// Xóa thông tin sinh viên khỏi hệ thống
        /// </summary>
        /// <param name="maSV">Mã sinh viên cần xóa</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool Xoa(string maSV)
        {
            string strDelete = "Delete from SinhVien where MaSV='" + maSV + "'";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@MaSV", SqlDbType.VarChar, 10);
            pars[0].Value = maSV;

            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
