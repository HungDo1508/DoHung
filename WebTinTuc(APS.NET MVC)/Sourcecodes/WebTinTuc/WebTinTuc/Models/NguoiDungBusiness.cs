using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebTinTuc.Models
{
    public class NguoiDungBusiness
    {
        public List<NguoiDung> TimKiemThongTin(string tuKhoa, string IdVaiTro)
        {
            IQueryable<NguoiDung> lstNguoiDung = DataProvider.Entities.NguoiDungs;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                lstNguoiDung = lstNguoiDung.Where(b => b.TenNguoiDung.Contains(tuKhoa)) ;
            }

            if (!string.IsNullOrEmpty(IdVaiTro))
            {
                lstNguoiDung = lstNguoiDung.Where(b => b.IdVaiTro != null && b.IdVaiTro.Equals(IdVaiTro));
            }

            return lstNguoiDung.ToList();

        }
        public List<NguoiDung> LayTaiKhoan(string tuKhoa)
        {
            IQueryable<NguoiDung> lstNguoiDung = DataProvider.Entities.NguoiDungs;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                lstNguoiDung = lstNguoiDung.Where(b => b.TaiKhoan.Contains(tuKhoa));
            }

            return lstNguoiDung.ToList();

        }
        public List<NguoiDung> LayDanhSach()
        {
            return DataProvider.Entities.NguoiDungs.ToList();
        }

        public NguoiDung LayChiTiet(int? Id)
        {
            NguoiDung objNguoiDung = DataProvider.Entities.NguoiDungs.Where(s => s.IdNguoiDung == Id).FirstOrDefault();

            return objNguoiDung;
        }

        public bool ThemMoi(NguoiDung objNguoiDung)
        {

            
            

            if (objNguoiDung != null)
            {
               
                DataProvider.Entities.NguoiDungs.Add(objNguoiDung);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CapNhat(NguoiDung objNguoiDung)
        {
            //Lấy thông tin sửa ra
            NguoiDung objNguoiDungOld = DataProvider.Entities.NguoiDungs.Where(s => s.IdNguoiDung == objNguoiDung.IdNguoiDung).FirstOrDefault();

            DataProvider.Entities.Entry(objNguoiDungOld).CurrentValues.SetValues(objNguoiDung);
            DataProvider.Entities.SaveChanges();

            return true;
        }

        public bool Xoa(int Id)
        {
            NguoiDung objNguoiDung = LayChiTiet(Id);

            if (objNguoiDung != null)
            {
                DataProvider.Entities.NguoiDungs.Remove(objNguoiDung);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }
    }
}