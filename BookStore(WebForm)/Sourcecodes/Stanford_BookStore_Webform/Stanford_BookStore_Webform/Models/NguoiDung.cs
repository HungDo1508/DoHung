using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stanford_BookStore_Webform.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        public string HoTen { get; set; }

        public string DienThoai { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }
    }
}