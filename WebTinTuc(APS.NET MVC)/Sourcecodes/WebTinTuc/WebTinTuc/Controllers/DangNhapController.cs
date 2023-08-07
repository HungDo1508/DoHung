using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    public class DangNhapController : Controller
    {
        NguoiDungBusiness nguoiDungBusiness = new NguoiDungBusiness();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {

            // Xừ lý hiển thị lấy thông tin tài khoản từ cookie
            HttpCookie objUserCookie = Request.Cookies.Get("username");

            DangNhapViewModel objUser = null;

            
            if(objUserCookie != null && objUserCookie.Value !=null)
            {

                NguoiDung objUserTemp = DataProvider.Entities.NguoiDungs.Where(m=>m.TaiKhoan.Equals(objUserCookie.Value)).FirstOrDefault<NguoiDung>();
                if(objUserTemp !=null)
                {
                    objUser = new DangNhapViewModel();
                    objUser.IdNguoiDung = objUserTemp.IdNguoiDung;
                    objUser.TaiKhoan = objUserTemp.TaiKhoan;
                    objUser.MatKhau = objUserTemp.MatKhau;

                }    
              }

           return View(objUser);

        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapViewModel model)
        {
            if(ModelState.IsValid)
            {
                var login = DataProvider.Entities.NguoiDungs.Where(m => m.TaiKhoan.Equals(model.TaiKhoan)).FirstOrDefault<NguoiDung>();
                if(login !=null)
                {
                    if (login.MatKhau.Equals(MaHoa.md5(model.MatKhau)))
                    {
                        Session["SessionId"] = login.IdNguoiDung.ToString();
                        Session["SessionHoTen"] = login.TenNguoiDung;
                        //Lưu thông tin người dùng vào session
                        Session["useronline"] = login;
                        return RedirectToAction("TrangChu", "Home");
                    
                    }
                    else
                    {
                        ModelState.AddModelError("","Mật khẩu không đúng.");
                        }
                }    
            }    
            
            return View();
        }
        public ActionResult DangXuat()
        {

            Session.RemoveAll();

            return RedirectToAction("TrangChu", "Home");
        }
        public ActionResult DangKi()
        {

            return View();
        }
        ///
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKi(NguoiDung objNguoiDung, string matKhau)
        {

            var taikhoan1 = DataProvider.Entities.NguoiDungs.Select(s => s.TaiKhoan).ToList();
            bool isMatch = taikhoan1.Any(obj => obj.Equals(objNguoiDung.TaiKhoan));
            if (isMatch == true)
            {
                ModelState.AddModelError("TaiKhoan", "Tên tài khoản này đã có người đăng kí");
            }
            if (ModelState.IsValid)//true
            {

                objNguoiDung.IdVaiTro = "TV";
                objNguoiDung.MatKhau = MaHoa.md5(matKhau);
                bool ketQua = nguoiDungBusiness.ThemMoi(objNguoiDung);

                if (ketQua)
                {
                    return RedirectToAction("DangNhap");
                }
            }

            return View();
        }
    }

}