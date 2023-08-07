using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebTinTuc.Models
{
    public class KiemTraQuyenAttribute : AuthorizeAttribute
    {
        public string PermissionName { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            NguoiDung objNguoiDung = (NguoiDung)HttpContext.Current.Session["useronline"];
            if(objNguoiDung != null)
            {
                //Lấy mã vai trò
                string VaiTroId = objNguoiDung.IdVaiTro;
                ChucNangPhamMem objChucNang =DataProvider.Entities.ChucNangPhamMems.Where(p =>p.TenForm.Equals(PermissionName)).First<ChucNangPhamMem>();
                if (objChucNang != null)
                {
                    VaiTro_ChucNangPhamMem objQuyen = null;
                    try
                    {
                        objQuyen = DataProvider.Entities.VaiTro_ChucNangPhamMem.Where(p => p.IdVaiTro != null && p.IdVaiTro.Equals(VaiTroId) && p.IdChucNang== objChucNang.IdChucNang).First<VaiTro_ChucNangPhamMem>();
                        if (objQuyen != null && objQuyen.Xem.HasValue)
                        {
                            if (objQuyen.Xem.Value)
                            {
                                return true;
                            }
                        }
                        
                    }
                    catch
                    {

                    }
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName ="~/Views/DangNhap/NotAuthorize.cshtml"
            };
        }
    }
}