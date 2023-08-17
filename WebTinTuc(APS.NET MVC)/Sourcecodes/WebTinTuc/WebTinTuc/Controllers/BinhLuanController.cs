using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    public class BinhLuanController : Controller
    {
        BinhLuanBusiness binhLuanBusiness = new BinhLuanBusiness();
        [KiemTraQuyen(PermissionName = "DanhSachBinhLuan")]
        public ActionResult DanhSachBinhLuan(string tuKhoa)
        {
 
            //Lấy danh sách sách
            List<BinhLuan> lstBinhLuan = binhLuanBusiness.TimKiemThongTin(tuKhoa);

            ViewBag.tuKhoa = tuKhoa;

            return View(lstBinhLuan);
        }
       
        public ActionResult ThemMoiBinhLuan()
        {

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult ThemMoiBinhLuan(int idbaiviet, int idnguoidung, string tenNguoiDung, BinhLuan objBinhLuan, HomeModel home)
        {
            if (ModelState.IsValid)//true
            {
                BinhLuanBusiness binhLuanBusiness = new BinhLuanBusiness();

                objBinhLuan.NgayBinhLuan = DateTime.Now;
                objBinhLuan.IdBaiViet = idbaiviet;
                objBinhLuan.IdNguoiDung = idnguoidung;
                objBinhLuan.TenNguoiDung = tenNguoiDung;
                objBinhLuan.NoiDung = home.comment.NoiDung;
                
                
                var rs = binhLuanBusiness.ThemMoi(objBinhLuan);
                var id = idbaiviet;
                if (rs == true)
                {
                    return RedirectToAction("ChiTiet", "Home" ,new { @id = id });
                }

            }
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBinhLuan")]
        public ActionResult SuaBinhLuan(int? id)
        {

            if (id > 0)
            {
                
                BinhLuan objBinhLuan = binhLuanBusiness.LayChiTiet(id);

                if (objBinhLuan != null)
                {
                    return View(objBinhLuan);
                }

            }

            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBinhLuan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaBinhLuan(int? id, BinhLuan objBinhLuan)
        {
            if (id > 0)
            {
                objBinhLuan.NgayBinhLuan = DateTime.Now;

                bool ketQua = binhLuanBusiness.CapNhat(objBinhLuan);

                if (ketQua)
                {
                    return RedirectToAction("DanhSachBinhLuan");
                }
            }
           
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBinhLuan")]
        public ActionResult XoaThongTin(int id)
        {
            if (id > 0)
            {
                BinhLuan objBinhLuan = binhLuanBusiness.LayChiTiet(id);

                if (objBinhLuan != null)
                {
                    binhLuanBusiness.Xoa(id);
                    return RedirectToAction("DanhSachBinhLuan");
                }
            }

            return View();
        }
    }
}