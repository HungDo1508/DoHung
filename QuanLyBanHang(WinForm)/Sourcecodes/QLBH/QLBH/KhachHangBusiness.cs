using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLBH
{
    public class KhachHangBusiness
    {
        /// <summary>
        /// Khai báo 1 biến để chứa danh sách các khách hàng
        /// </summary>
        private List<KhachHang> lstKhachHang= new List<KhachHang>();
        /// <summary>
        /// Hàm lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaKhachHang,TenKhachHang, DienThoai, Email, DiaChi, MaLoai from KhachHang";

            return DataProvider.LayDanhSach(strSQL);
        }
        public DataTable LayTenKhach()
        {
            string strSQL = "Select MaKhachHang from KhachHang";

            return DataProvider.LayDanhSach(strSQL);
        }

        public DataTable TimKiemKhachHang(string tuKhoa, string maLoai)
        {
            string strSQL = "Select MaKhachHang,TenKhachHang, DienThoai, Email, DiaChi, MaLoai from KhachHang where 1=1";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (MaKhachHang='{0}' OR TenKhachHang like N'%{0}%' OR DienThoai like '%{0}%' OR Email like '%{0}%')", tuKhoa);
            }

            if (!string.IsNullOrEmpty(maLoai))
            {
                strSQL += string.Format(" AND MaLoai='{0}'", maLoai);
            }

            return DataProvider.LayDanhSach(strSQL);
        }
        public bool ThemMoi(KhachHang objKH)
        {
            string strInsert = "Insert into KhachHang(MaKhachHang,TenKhachHang, DienThoai, Email, DiaChi, MaLoai) values(@MaKhachHang,@TenKhachHang, @DienThoai, @Email, @DiaChi, @MaLoai)";

            SqlParameter[] pars = new SqlParameter[6];

            pars[0] = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 10);
            pars[0].Value = objKH.MaKhachHang;

            pars[1] = new SqlParameter("@TenKhachHang", SqlDbType.NVarChar, 30);
            pars[1].Value = objKH.TenKhachHang;

            pars[2] = new SqlParameter("@DienThoai", SqlDbType.VarChar, 20);
            pars[2].Value = objKH.DienThoai;

            pars[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            pars[3].Value = objKH.Email;

            pars[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
            pars[4].Value = objKH.DiaChi;

            pars[5] = new SqlParameter("@MaLoai", SqlDbType.VarChar, 10);
            pars[5].Value = objKH.MaLoai;

            return DataProvider.ThucHien(strInsert, pars);
        }
        public bool CapNhat(KhachHang objKH)
        {
            string strUpdate = "Update KhachHang set TenKhachHang=@TenKhachHang, DienThoai=@DienThoai, Email=@Email, DiaChi=@DiaChi,  MaLoai=@MaLoai where MaKhachHang=@MaKhachHang";


            SqlParameter[] pars = new SqlParameter[6];

            pars[0] = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 10);
            pars[0].Value = objKH.MaKhachHang;

            pars[1] = new SqlParameter("@TenKhachHang", SqlDbType.NVarChar, 30);
            pars[1].Value = objKH.TenKhachHang;

            pars[2] = new SqlParameter("@DienThoai", SqlDbType.VarChar, 20);
            pars[2].Value = objKH.DienThoai;

            pars[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            pars[3].Value = objKH.Email;

            pars[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250);
            pars[4].Value = objKH.DiaChi;

            pars[5] = new SqlParameter("@MaLoai", SqlDbType.VarChar, 10);
            pars[5].Value = objKH.MaLoai;


            return DataProvider.ThucHien(strUpdate, pars);
        }
        public bool Xoa(string maKH)
        {
            string strDelete = "Delete from KhachHang where MaKhachHang='" + maKH + "'";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 10);
            pars[0].Value = maKH;

            return DataProvider.ThucHien(strDelete, pars);
        }
        public KhachHang LayChiTietTheoMa(string maKH)
        {
            //Khai báo biến
            KhachHang objKhachHang = null;

            string strSQL = "Select * from KhachHang where MaKhachHang ='" + maKH + "'";

            DataTable dtKH = DataProvider.LayDanhSach(strSQL);

            if (dtKH != null && dtKH.Rows.Count > 0)
            {
                objKhachHang = new KhachHang();

                objKhachHang.MaKhachHang = "" + dtKH.Rows[0]["MaKhachHang"];
                objKhachHang.TenKhachHang = "" + dtKH.Rows[0]["TenKhachHang"];
                objKhachHang.DienThoai = "" + dtKH.Rows[0]["DienThoai"];
                objKhachHang.Email = "" + dtKH.Rows[0]["Email"];
                objKhachHang.DiaChi = "" + dtKH.Rows[0]["DiaChi"];
                objKhachHang.MaLoai = "" + dtKH.Rows[0]["MaLoai"];
            }

            return objKhachHang;
        }
    }
}
