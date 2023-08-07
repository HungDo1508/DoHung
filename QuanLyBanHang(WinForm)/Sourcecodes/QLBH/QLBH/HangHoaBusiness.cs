using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLBH
{
    public class HangHoaBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "Select MaHang , TenHang, MoTa ,XuatXu from HangHoa ";
            return DataProvider.LayDanhSach(strSQL);
        }
        public DataTable LayMaHang()
        {
            string strSQL = "Select MaHang from HangHoa ";
            return DataProvider.LayDanhSach(strSQL);
        }
        public DataTable TimKiemHangHoa(string tuKhoa)
        {
            string strSQL = "Select MaHang , TenHang, MoTa ,XuatXu from HangHoa where 1=1";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (MaHang='{0}' OR TenHang like N'%{0}%' OR MoTa like '%{0}%' OR XuatXu like '%{0}%')", tuKhoa);
            }

            return DataProvider.LayDanhSach(strSQL);
        }
        public bool ThemMoi(HangHoa objHH)
        {
            string strInsert = "Insert into HangHoa(MaHang,TenHang,MoTa,XuatXu) values(@MaHang,@TenHang,@MoTa,@XuatXu)";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaHang", SqlDbType.VarChar, 10);
            pars[0].Value = objHH.MaHang;

            pars[1] = new SqlParameter("@TenHang", SqlDbType.NVarChar, 20);
            pars[1].Value = objHH.TenHang;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHH.MoTa;

            pars[3] = new SqlParameter("@XuatXu", SqlDbType.NVarChar, 30);
            pars[3].Value = objHH.XuatXu;
            return DataProvider.ThucHien(strInsert, pars);
        }
        public bool CapNhat(HangHoa objHH)
        {
            string strUpdate = "Update HangHoa set TenHang=@TenHang, MoTa=@MoTa, XuatXu=@XuatXu where MaHang=@MaHang";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaHang", SqlDbType.VarChar, 10);
            pars[0].Value = objHH.MaHang;

            pars[1] = new SqlParameter("@TenHang", SqlDbType.NVarChar, 20);
            pars[1].Value = objHH.TenHang;

            pars[2] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[2].Value = objHH.MoTa;

            pars[3] = new SqlParameter("@XuatXu", SqlDbType.NVarChar, 30);
            pars[3].Value = objHH.XuatXu;

            return DataProvider.ThucHien(strUpdate, pars);
        }
        public bool Xoa(string maHH)
        {
            string strDelete = "Delete from HangHoa where MaHang='" + maHH + "'";

            SqlParameter[] pars = new SqlParameter[1];

            pars[0] = new SqlParameter("@MaHang", SqlDbType.VarChar, 10);
            pars[0].Value = maHH;

            return DataProvider.ThucHien(strDelete, pars);
        }
        public HangHoa LayChiTietTheoMa(string maHH)
        {
            //Khai báo biến
            HangHoa objHangHoa = null;

            string strSQL = "Select * from HangHoa where MaHang ='" + maHH + "'";

            DataTable dtHH = DataProvider.LayDanhSach(strSQL);

            if (dtHH != null && dtHH.Rows.Count > 0)
            {
                objHangHoa = new HangHoa();

                objHangHoa.MaHang = "" + dtHH.Rows[0]["MaHang"];
                objHangHoa.TenHang = "" + dtHH.Rows[0]["TenHang"];
                objHangHoa.MoTa = "" + dtHH.Rows[0]["MoTa"];
                objHangHoa.XuatXu = "" + dtHH.Rows[0]["XuatXu"];
            }

            return objHangHoa;
        }
    }
}
