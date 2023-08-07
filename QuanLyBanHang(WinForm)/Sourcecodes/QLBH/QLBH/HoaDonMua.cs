using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
    public class HoaDonMua
    {
        public HoaDonMua(string MaHoaDon, string TenHoaDon, string MoTa, DateTime NgayMua)
        {
            this.MaHoaDon = MaHoaDon;
            this.TenHoaDon = TenHoaDon;
            this.MoTa = MoTa;
            this.NgayMua = NgayMua;
        }
        public HoaDonMua()
        {
            }

        public string MaHoaDon { get; set; }
        public string TenHoaDon { get; set; }
        public string MoTa { get; set; }
        public  DateTime NgayMua{ get; set; }
    }
}
