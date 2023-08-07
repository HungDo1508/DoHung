using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
     public class HoaDonBan
    {
        public HoaDonBan(string MaHoaDon, string TenHoaDon, string MoTa, DateTime NgayBan , string MaKhachHang)
        {
            this.MaHoaDon = MaHoaDon;
            this.TenHoaDon = TenHoaDon;
            this.MoTa = MoTa;
            this.NgayBan = NgayBan;
            this.MaKhachHang = MaKhachHang;
        }
        public HoaDonBan()
        {
        }

        public string MaHoaDon { get; set; }
        public string TenHoaDon { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKhachHang { get; set; }
    }
}
