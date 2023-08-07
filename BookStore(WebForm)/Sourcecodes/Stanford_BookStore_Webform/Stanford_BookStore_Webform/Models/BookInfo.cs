using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stanford_BookStore_Webform.Models
{
    public class BookInfo
    {
        /// <summary>
        /// Hàm khởi tạo không có tham số
        /// </summary>
        public BookInfo()
        {
            NgayTao = DateTime.Now;
        }

        /// <summary>
        /// Hàm khởi tạo có 6 tham số
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenSach"></param>
        /// <param name="moTa"></param>
        /// <param name="tacGia"></param>
        /// <param name="giaSach"></param>
        /// <param name="anhDaiDien"></param>
        public BookInfo(int id, string tenSach, string moTa, string tacGia, double giaSach, string anhDaiDien)
        {
            Id = id;
            TenSach = tenSach;
            MoTa = moTa;
            TacGia = tacGia;
            GiaSach = giaSach;
            AnhSach = anhDaiDien;
        }

        public int Id { get; set; }

        public string TenSach { get; set; }

        public string MoTa { get; set; }

        public string TacGia { get; set; }

        public double GiaSach { get; set; }

        public string AnhSach { get; set; }

        public string MaChuDe { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgayCapNhat { get; set; }

        public DateTime NgayXuatBan { get; set; }
    }
}