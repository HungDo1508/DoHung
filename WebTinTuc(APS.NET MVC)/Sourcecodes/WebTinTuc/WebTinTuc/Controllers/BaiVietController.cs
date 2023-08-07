using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTinTuc.Models;
using PagedList;
using System.Net;

namespace WebTinTuc.Controllers
{
    public class BaiVietController : Controller
    {
        BaiVietBusiness baiVietBusiness = new BaiVietBusiness();
        private BaiViet db = new BaiViet();
        // GET: BaiViet
        [KiemTraQuyen(PermissionName = "DanhSachBaiViet")]

        public ActionResult DanhSach(string tuKhoa, string IdDanhMuc, int? page, string tenTacGia, string trangThai , DateTime? start, DateTime? end)
        {
            HienThiDanhMuc(IdDanhMuc);
            
            List<BaiViet> lstBaiViet = baiVietBusiness.TimKiemThongTinAD(tuKhoa , IdDanhMuc , tenTacGia ,trangThai, start, end);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.tuKhoa = tuKhoa;
            ViewBag.tenTacGia = tenTacGia;
            ViewBag.start = start;
            ViewBag.end = end;
            ViewBag.trangThai = trangThai;
           

            //ViewBag.ngayKhoiDau = startDate;
            //ViewBag.ngayKetThuc = endDate;



            return View(lstBaiViet.ToPagedList(pageNumber, pageSize) );
            
        }
        [HttpPost]
        public JsonResult ChangeStatus( long id)
        {
            var result = baiVietBusiness.ChangeStatus(id);
                return Json(new  { 
                    TrangThai =result
                });;
        }
        [HttpGet]
        public ActionResult DuyetBaiViet(string strID)
        {
            if (strID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] strArrID = strID.Split('-');
            List<int> lstID = new List<int>();
            int id = 0;
            foreach (var item in strArrID)
            {
                if (item != "")
                {
                    if (int.TryParse(item, out id))
                    {
                        lstID.Add(id);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            BaiViet objBaiViet = new BaiViet();
            foreach (var item in lstID)
            {
                objBaiViet = DataProvider.Entities.BaiViets.Where(x => x.IdBaiViet == item).FirstOrDefault();
              
                if (objBaiViet == null)
                {
                    return HttpNotFound();
                }
                if (objBaiViet.TrangThai == false)
                {
                    objBaiViet.TrangThai = true;
                    objBaiViet.NgayXuatBan = DateTime.Now;
                }
            }
            DataProvider.Entities.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        [HttpGet]
        public ActionResult HuyDuyetBaiViet(string strID)
        {
            if (strID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string[] strArrID = strID.Split('-');
            List<int> lstID = new List<int>();
            int id = 0;
            foreach (var item in strArrID)
            {
                if (item != "")
                {
                    if (int.TryParse(item, out id))
                    {
                        lstID.Add(id);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            BaiViet objBaiViet = new BaiViet();
            foreach (var item in lstID)
            {
                objBaiViet = DataProvider.Entities.BaiViets.Where(x => x.IdBaiViet == item).FirstOrDefault();

                if (objBaiViet == null)
                {
                    return HttpNotFound();
                }
                if (objBaiViet.TrangThai == true)
                {
                    objBaiViet.TrangThai = false;
                  
                }
            }
            DataProvider.Entities.SaveChanges();
            return RedirectToAction("DanhSach");
        }
       
        private void HienThiLoaiTin(string maLT = null)
        {
            LoaiTinBusiness loaiTinBusiness = new LoaiTinBusiness();

            List<LoaiTinViewModel> lstLoaiTin = loaiTinBusiness.LayDanhSach();

            ViewBag.LoaiTin = new SelectList(lstLoaiTin, "IdLoaiTin", "TenLoaiTin", maLT != null ? maLT : "");
        }
        private void HienThiDanhMuc(string maDM = null)
        {
           DanhMucBusiness danhMucBusiness = new DanhMucBusiness();

            List<DanhMucViewModel> lstDanhMuc = danhMucBusiness.LayDanhSach();

            ViewBag.DanhMuc = new SelectList(lstDanhMuc, "IdDanhMuc", "TenDanhMuc", maDM != null ? maDM : "");
        }

        [KiemTraQuyen(PermissionName = "ThemMoiBaiViet")]
        public ActionResult ThemMoi()
        {
            HienThiDanhMuc();
            HienThiLoaiTin();
            return View();
        }

        /// <summary>
        /// Hàm hiển thị danh sách chủ đề
        /// </summary>
        /// <param name="maCD"></param>


        [KiemTraQuyen(PermissionName = "ThemMoiBaiViet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemMoi( BaiViet objBaiViet, HttpPostedFileBase fUpload)
        {
            HienThiDanhMuc(objBaiViet.IdDanhMuc);
            HienThiLoaiTin(objBaiViet.IdLoaiTin);
           
           
            if (ModelState.IsValid)//true
            {
                // Xử lý upload file
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(fUpload.FileName);
                    fUpload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lấy tên ảnh để lưu vào db
                    objBaiViet.AnhBaiViet = fileName;
                }
                //test mã hóa
                // objBaiViet.NoiDung =MaHoa.md5("");
                objBaiViet.TrangThai = false;
                objBaiViet.NgayTao = DateTime.Now;
                objBaiViet.NgayCapNhat = DateTime.Now;

                bool ketQua = baiVietBusiness.ThemMoi(objBaiViet);

                if (ketQua)
                {
                    TempData["SuccessMessage"] = "Them thanh cong ";
                    return RedirectToAction("TrangChu", "Home");
                }
            }
            
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBaiViet")]
        public ActionResult SuaBaiViet(int?id)
        {

            if (id > 0)
            {
                BaiViet objBaiViet = baiVietBusiness.LayChiTiet(id);
                HienThiDanhMuc(objBaiViet.IdDanhMuc);
                HienThiLoaiTin(objBaiViet.IdLoaiTin);

                if (objBaiViet != null)
                {
                    return View(objBaiViet);
                }
                
            }

            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBaiViet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaBaiViet(int? id, BaiViet objBaiViet, HttpPostedFileBase fUpload)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)//true
                {
                    // Xử lý upload file
                    if (fUpload != null && fUpload.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(fUpload.FileName);
                        fUpload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                        //Lấy tên ảnh để lưu vào db
                        objBaiViet.AnhBaiViet = fileName;
                    }
                    objBaiViet.NgayCapNhat = DateTime.Now;

                    bool ketQua = baiVietBusiness.CapNhat(objBaiViet);

                    if (ketQua)
                    {
                        return RedirectToAction("DanhSach");
                    }
                }
            }
            HienThiDanhMuc(objBaiViet.IdDanhMuc);
            HienThiLoaiTin(objBaiViet.IdLoaiTin);
            return View();
        }
        [KiemTraQuyen(PermissionName = "DanhSachBaiViet")]
        public ActionResult XoaThongTin(int id)
        {
            if (id > 0)
            {
                BaiViet objBaiViet = baiVietBusiness.LayChiTiet(id);

                if (objBaiViet != null)
                {
                    baiVietBusiness.Xoa(id);
                    return RedirectToAction("DanhSach");
                }
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(int idbaiviet, int idnguoidung ,string tenNguoiDung, BinhLuan objBinhLuan , BaiViet bv )
        {
            if (ModelState.IsValid)//true
            {
                BinhLuanBusiness binhLuanBusiness = new BinhLuanBusiness();
                
                objBinhLuan.NgayBinhLuan = DateTime.Now;
                objBinhLuan.IdBaiViet = idbaiviet;
                objBinhLuan.IdNguoiDung = idnguoidung;
                objBinhLuan.TenNguoiDung = tenNguoiDung;
                objBinhLuan.NoiDung = bv.comment.NoiDung;

                
                var rs = binhLuanBusiness.ThemMoi(objBinhLuan);
                var id = idbaiviet;
                if (rs == true)
                {
                    return RedirectToAction("ChiTiet", "Home", new { @id = id });
                }
              
            }    
                return View("ChiTiet");
        }



    }
}