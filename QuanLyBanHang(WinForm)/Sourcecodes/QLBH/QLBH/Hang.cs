using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
     public class Hang
    {
        public Hang()
        {
           
        }
        public Hang(string MaHoaDon, string MaHang, string TenHang, int SoLuong, int GiaMua,int thanhTien)
        {
            this.MaHoaDon = MaHoaDon;
            this.MaHang = MaHang;
            this.TenHang = TenHang;
            this.SoLuong = SoLuong;
            this.GiaMua = GiaMua;
            this.ThanhTien = thanhTien;
           

        }
        public string MaHang { get; set; }
        public string MaHoaDon { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public int GiaMua { get; set; }
        public int ThanhTien { get; set; }
       
    }
}
