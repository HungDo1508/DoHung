using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace QLBH
{
    public class HoaDonMuaBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaHoaDon,TenHoaDon, MoTa, NgayMua from HoaDonMua";

            return DataProvider.LayDanhSach(strSQL);
        }
        public DataTable LayMaHoaDon()
        {
            string strSQL = "Select MaHoaDon from HoaDonMua";

            return DataProvider.LayDanhSach(strSQL);
        }
        public HoaDonMua LayChiTietTheoMa(string maHoaDon)
        {
            //Khai báo biến
            HoaDonMua objHoaDonMua = null;

            string strSQL = "Select * from HoaDonMua where MaHoaDon ='" + maHoaDon + "'";

            DataTable dtHDM = DataProvider.LayDanhSach(strSQL);

            if (dtHDM != null && dtHDM.Rows.Count > 0)
            {
                objHoaDonMua = new HoaDonMua();

                objHoaDonMua.MaHoaDon = "" + dtHDM.Rows[0]["MaHoaDon"];
                objHoaDonMua.TenHoaDon = "" + dtHDM.Rows[0]["TenHoaDon"];
                DateTime ngayMua;
                DateTime.TryParse("" + dtHDM.Rows[0]["NgayMua"], out ngayMua);
                objHoaDonMua.NgayMua = ngayMua;
                objHoaDonMua.MoTa = "" + dtHDM.Rows[0]["MoTa"];
                
            }

            return objHoaDonMua;
        }
        public bool ThemMoi(HoaDonMua objHDM)
        {
            string strInsert = "Insert into HoaDonMua(MaHoaDon, TenHoaDon, MoTa, NgayMua) values(@MaHoaDon, @TenHoaDon, @MoTa, @NgayMua)";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = objHDM.MaHoaDon;

            pars[1] = new SqlParameter("@TenHoaDon", SqlDbType.NVarChar, 30);
            pars[1].Value = objHDM.TenHoaDon;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHDM.MoTa;

            pars[3] = new SqlParameter("@NgayMua", SqlDbType.Date);
            pars[3].Value = objHDM.NgayMua;

            return DataProvider.ThucHien(strInsert, pars);
        }
        public bool CapNhat(HoaDonMua objHDM)
        {
            string strUpdate = "Update HoaDonMua set MaHoaDon=@MaHoaDon ,TenHoaDon=@TenHoaDon, MoTa=@MoTa, NgayMua=@NgayMua where MaHoaDon=@MaHoaDon";


            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = objHDM.MaHoaDon;

            pars[1] = new SqlParameter("@TenHoaDon", SqlDbType.NVarChar, 30);
            pars[1].Value = objHDM.TenHoaDon;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHDM.MoTa;

            pars[3] = new SqlParameter("@NgayMua", SqlDbType.Date);
            pars[3].Value = objHDM.NgayMua;

            return DataProvider.ThucHien(strUpdate, pars);
        }
        public bool Xoa(string maHoaDon)
        {
            string strDelete = "Delete from HoaDonMua where MaHoaDon='" + maHoaDon + "'";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = maHoaDon;

            return DataProvider.ThucHien(strDelete, pars);
        }
    }
}
