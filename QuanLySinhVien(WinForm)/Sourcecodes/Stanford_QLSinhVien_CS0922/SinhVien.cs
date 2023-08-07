using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stanford_QLSinhVien_CS0922
{
    public class SinhVien
    {
        /// <summary>
        /// Hàm khởi tạo không có tham số
        /// </summary>
        public SinhVien()
        {
            this.DiaChi = "Hà Nội";
        }

        /// <summary>
        /// Hàm khởi tạo có 1 tham số
        /// </summary>
        /// <param name="DiaChi"></param>
        public SinhVien(string DiaChi)
        {
            this.DiaChi = DiaChi;
        }

        /// <summary>
        /// Hàm khởi tạo có 5 tham số
        /// </summary>
        /// <param name="MaSV"></param>
        /// <param name="HoTen"></param>
        /// <param name="DienThoai"></param>
        /// <param name="Email"></param>
        /// <param name="DiaChi"></param>
        public SinhVien(string MaSV, string HoTen, string DienThoai, string Email, string DiaChi)
        {
            this.MaSV = MaSV;
            this.HoTen = HoTen;
            this.DienThoai = DienThoai;
            this.Email = Email;
            this.DiaChi = DiaChi;
        }
    
        /// <summary>
        /// Khai báo 1 thuộc tính sinh viên
        /// </summary>
        private string _MaSV = "";

        public string MaSV
        {
            get { return _MaSV; }
            set
            {
                _MaSV = value;
            }
        }

        public string HoTen { get; set; }

        public int GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string DienThoai { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string MaKhoa { get; set; }
    }
}
