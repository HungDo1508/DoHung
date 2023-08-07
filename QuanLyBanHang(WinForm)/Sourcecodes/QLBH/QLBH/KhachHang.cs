using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH
{
     public class KhachHang
    {
        public KhachHang(string MaKhachHang, string TenKhachHang, string DienThoai, string Email, string DiaChi,string MaLoai)
        {
            this.MaKhachHang = MaKhachHang;
            this.TenKhachHang = TenKhachHang;
            this.DienThoai = DienThoai;
            this.Email = Email;
            this.DiaChi = DiaChi;
            this.MaLoai = MaLoai;
        }
        public KhachHang()
        {
           
        }

        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MaLoai { get; set; }
    }
}
