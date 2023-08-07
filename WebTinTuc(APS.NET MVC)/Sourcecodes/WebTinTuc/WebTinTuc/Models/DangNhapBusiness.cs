using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class DangNhapBusiness
    {
        public List<DangNhapViewModel> LayDanhSach()
        {
            List<DangNhapViewModel> lstDangNhap = (from item in DataProvider.Entities.NguoiDungs
                                                 select new DangNhapViewModel()
                                                 {
                                                     IdNguoiDung = item.IdNguoiDung,
                                                     TaiKhoan = item.TaiKhoan,
                                                     MatKhau = item.MatKhau,
                                                     TenNguoiDung=item.TenNguoiDung
                                                 }).ToList();

            return lstDangNhap;
        }
    }
}