using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;

namespace WebTinTuc.Controllers
{
    public class NguoiDungController : Controller
    {
        NguoiDungBusiness nguoiDungBusiness = new NguoiDungBusiness();
        // GET: BaiViet
        public ActionResult Index()
        {
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        public ActionResult DanhSachNguoiDung(string tuKhoa, string IdVaiTro)
        {
            HienThiVaiTro(IdVaiTro);

            //Lấy danh sách sách
            List<NguoiDung> lstNguoiDung = nguoiDungBusiness.TimKiemThongTin(tuKhoa, IdVaiTro);

            ViewBag.tuKhoa = tuKhoa;

            return View(lstNguoiDung);
        }
        private void HienThiVaiTro(string maVT = null)
        {
            VaiTroBusiness vaiTroBusiness = new VaiTroBusiness();

            List<VaiTroViewModel> lstVaiTro = vaiTroBusiness.LayDanhSach();

            ViewBag.VaiTro = new SelectList(lstVaiTro, "IdVaiTro", "TenVaiTro", maVT != null ? maVT : "");
        }

        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        public ActionResult ThemMoiTTNguoiDung()
        {
            
            return View();
        }

        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiTTNguoiDung(NguoiDung objNguoiDung, string matKhau  )
        {

            var taikhoan = DataProvider.Entities.NguoiDungs.Select(s => s.TaiKhoan).ToList();
            bool isMatch = taikhoan.Any(obj => obj.Equals(objNguoiDung.TaiKhoan));
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
                    return RedirectToAction("DanhSachNguoiDung");
                }
            }
            
            return View();
        }

        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        public ActionResult SuaTTNguoiDung(int? id)
        {

            if (id > 0)
            {

                NguoiDung objNguoiDung = nguoiDungBusiness.LayChiTiet(id);
                HienThiVaiTro(objNguoiDung.IdVaiTro);
                
                if (objNguoiDung != null)
                {
                    return View(objNguoiDung);
                }

            }

            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaTTNguoiDung(int? id, NguoiDung objNguoiDung ,string matKhau)
        {
            if (id > 0)
            {
                objNguoiDung.MatKhau = MaHoa.md5(matKhau);

                bool ketQua = nguoiDungBusiness.CapNhat(objNguoiDung);

                if (ketQua)
                {
                    return RedirectToAction("DanhSachNguoiDung");
                }
            }
            HienThiVaiTro(objNguoiDung.IdVaiTro);
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachNguoiDung")]
        public ActionResult XoaThongTin(int id)
        {
            if (id > 0)
            {
                NguoiDung objNguoiDung = nguoiDungBusiness.LayChiTiet(id);

                if (objNguoiDung != null)
                {
                    nguoiDungBusiness.Xoa(id);
                    return RedirectToAction("DanhSachNguoiDung");
                }
            }

            return View();
        }
       
    }
}
