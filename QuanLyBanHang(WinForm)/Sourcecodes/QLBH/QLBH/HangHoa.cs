using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
    
    public class HangHoa
    {
        public HangHoa()
        {
            
        }
        public HangHoa(string MaHang, string TenHang, string MoTa, string XuatXu)
        {
            this.MaHang = MaHang;
            this.TenHang = TenHang;
            this.MoTa = MoTa;
            this.XuatXu = XuatXu;
        }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MoTa { get; set; }
        public string XuatXu { get; set; }

    }
}
