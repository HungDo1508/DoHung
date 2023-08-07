using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLBH
{
    public class HoaDonBanBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaHoaDon,TenHoaDon, MoTa, NgayBan , MaKhachHang from HoaDonBan";

            return DataProvider.LayDanhSach(strSQL);
        }
        public HoaDonBan LayChiTietTheoMa(string maHoaDon )
        {
            //Khai báo biến
            HoaDonBan objHoaDonBan = null;

            string strSQL = "Select * from HoaDonBan where MaHoaDon ='" + maHoaDon + "'";

            DataTable dtHDB = DataProvider.LayDanhSach(strSQL);

            if (dtHDB != null && dtHDB.Rows.Count > 0)
            {
                objHoaDonBan = new HoaDonBan();

                objHoaDonBan.MaHoaDon = "" + dtHDB.Rows[0]["MaHoaDon"];
                objHoaDonBan.MaKhachHang = "" + dtHDB.Rows[0]["MaKhachHang"];
                objHoaDonBan.TenHoaDon = "" + dtHDB.Rows[0]["TenHoaDon"];
                DateTime ngayBan;
                DateTime.TryParse("" + dtHDB.Rows[0]["NgayBan"], out ngayBan);
                objHoaDonBan.NgayBan = ngayBan;
                objHoaDonBan.MoTa = "" + dtHDB.Rows[0]["MoTa"];
                

            }

            return objHoaDonBan;
        }
        public bool ThemMoi(HoaDonBan objHDB)
        {
            string strInsert = "Insert into HoaDonBan(MaHoaDon, TenHoaDon, MoTa, NgayBan , MaKhachHang) values(@MaHoaDon, @TenHoaDon, @MoTa, @NgayBan , @MaKhachHang)";

            SqlParameter[] pars = new SqlParameter[5];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = objHDB.MaHoaDon;

            pars[1] = new SqlParameter("@TenHoaDon", SqlDbType.NVarChar, 30);
            pars[1].Value = objHDB.TenHoaDon;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHDB.MoTa;

            pars[3] = new SqlParameter("@NgayBan", SqlDbType.Date);
            pars[3].Value = objHDB.NgayBan;

            pars[4] = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 10);
            pars[4].Value = objHDB.MaKhachHang;
            return DataProvider.ThucHien(strInsert, pars);
        }
        public bool CapNhat(HoaDonBan objHDB)
        {
            string strUpdate = "Update HoaDonBan set MaHoaDon=@MaHoaDon ,TenHoaDon=@TenHoaDon, MoTa=@MoTa, NgayBan=@NgayBan , MaKhachHang=@MaKhachHang where MaHoaDon=@MaHoaDon";

            SqlParameter[] pars = new SqlParameter[5];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = objHDB.MaHoaDon;

            pars[1] = new SqlParameter("@TenHoaDon", SqlDbType.NVarChar, 30);
            pars[1].Value = objHDB.TenHoaDon;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHDB.MoTa;

            pars[3] = new SqlParameter("@NgayBan", SqlDbType.Date);
            pars[3].Value = objHDB.NgayBan;

            pars[4] = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 10);
            pars[4].Value = objHDB.MaKhachHang;

            return DataProvider.ThucHien(strUpdate, pars);
        }
        public bool Xoa(string maHoaDon)
        {
            string strDelete = "Delete from HoaDonBan where MaHoaDon='" + maHoaDon + "'";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = maHoaDon;

            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
