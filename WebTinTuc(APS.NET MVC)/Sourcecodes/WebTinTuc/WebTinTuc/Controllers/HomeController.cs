using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{

   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult TrangChu()
        {
          
            BaiVietBusiness baiVietBusiness = new BaiVietBusiness();
            List<BaiViet> lstBaiViet = baiVietBusiness.TimKiemThongTin("", "");
           
            return View(lstBaiViet);

        }
        private void HienThiDanhMuc(string maDM = null)
        {
            DanhMucBusiness danhMucBusiness = new DanhMucBusiness();

            List<DanhMucViewModel> lstDanhMuc = danhMucBusiness.LayDanhSach();

            ViewBag.DanhMuc = new SelectList(lstDanhMuc, "IdDanhMuc", "TenDanhMuc", maDM != null ? maDM : "");
        }
        public ActionResult DanhSachTin(int? page , string IdDanhMuc , string tuKhoa)
        {
            HienThiDanhMuc(IdDanhMuc);
            BaiVietBusiness baiVietBusiness = new BaiVietBusiness();
            List<BaiViet> lstBaiViet = baiVietBusiness.TimKiemThongTin(tuKhoa, IdDanhMuc);
            ViewBag.tuKhoa = tuKhoa;

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(lstBaiViet.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult ChiTiet( int id)
        {
            BaiVietBusiness baiVietBusiness = new BaiVietBusiness();

            BaiViet objBaiViet = baiVietBusiness.LayChiTiet(id);

            return View(objBaiViet);

        }
       

    }
}