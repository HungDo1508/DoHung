using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLBH
{
    public class HangBusiness
    {
      
        public DataTable LayDanhSach()
        { 
            string strSQL = "Select MaHoaDon, MaHang , SoLuong, GiaMua ,ThanhTien from HoaDonMuaChiTiet ";
            return DataProvider.LayDanhSach(strSQL);
        }
      
        public Hang LayChiTietTheoMa(string maHoaDon)
        {
            //Khai báo biến
            Hang objHang = null;

            
            string strSQL = "Select * from HoaDonMuaChiTiet where MaHoaDon ='" + maHoaDon + "'";
            DataTable dtHang = DataProvider.LayDanhSach(strSQL);

            if (dtHang != null && dtHang.Rows.Count > 0)
            {
                objHang = new Hang();

                objHang.MaHoaDon = "" + dtHang.Rows[0]["MaHoaDon"];
              
            }

            return objHang;
        }
        public DataTable LocHoaDon(string maHoaDon)
        {
            string strSQL = "Select * from HoaDonMuaChiTiet where 1=1";

                strSQL += string.Format(" AND MaHoaDon='{0}'", maHoaDon);
          

            return DataProvider.LayDanhSach(strSQL);
        }
        
        public bool ThemMoi(Hang objHang)
        {
            string strInsert = "Insert into HoaDonMuaChiTiet(MaHoaDon,MaHang,SoLuong,GiaMua,ThanhTien) values(@MaHoaDon,@MaHang,@SoLuong,@GiaMua,@ThanhTien)";

            SqlParameter[] pars = new SqlParameter[5];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = objHang.MaHoaDon;
            pars[1] = new SqlParameter("@MaHang", SqlDbType.VarChar, 10);
            pars[1].Value = objHang.MaHang;
            pars[2] = new SqlParameter("@SoLuong", SqlDbType.Int);
            pars[2].Value = objHang.SoLuong;
            pars[3] = new SqlParameter("@GiaMua", SqlDbType.Int);
            pars[3].Value = objHang.GiaMua;
            pars[4] = new SqlParameter("@ThanhTien", SqlDbType.Int);
            pars[4].Value = objHang.ThanhTien;
            

            return DataProvider.ThucHien(strInsert, pars);
        }
        
        public bool Xoa(string maHang, string maHoaDon)
        {
            string strDelete = "Delete from HoaDonMuaChiTiet where MaHang='" + maHang + "'AND MaHoaDon='" + maHoaDon +"'" ;

            SqlParameter[] pars = new SqlParameter[2];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar, 10);
            pars[0].Value = maHoaDon;
            pars[1] = new SqlParameter("@MaHang", SqlDbType.VarChar, 10);
            pars[1].Value = maHang;
            

            return DataProvider.ThucHien(strDelete, pars);
        }

    }
}
