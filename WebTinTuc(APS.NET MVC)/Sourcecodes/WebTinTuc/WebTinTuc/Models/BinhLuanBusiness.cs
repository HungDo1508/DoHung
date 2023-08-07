using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class BinhLuanBusiness
    {
        public List<BinhLuan> TimKiemThongTin(string tuKhoa )
        {
            IQueryable<BinhLuan> lstBinhLuan = DataProvider.Entities.BinhLuans;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                lstBinhLuan = lstBinhLuan.Where(b => b.TenNguoiDung.Contains(tuKhoa) || b.NoiDung.Contains(tuKhoa));
            }


            return lstBinhLuan.ToList();

        }
        public List<BinhLuan> LayDanhSach()
        {
            return DataProvider.Entities.BinhLuans.ToList();
        }

        public BinhLuan LayChiTiet(int? Id)
        {
            BinhLuan objBinhLuan = DataProvider.Entities.BinhLuans.Where(s => s.IdBinhLuan == Id).FirstOrDefault();

            return objBinhLuan;
        }

        public bool ThemMoi(BinhLuan objBinhLuan)
        {
            if (objBinhLuan != null)
            {
                DataProvider.Entities.BinhLuans.Add(objBinhLuan);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CapNhat(BinhLuan objBinhLuan)
        {
            //Lấy thông tin sửa ra
            BinhLuan objBinhLuanOld = DataProvider.Entities.BinhLuans.Where(s => s.IdBinhLuan == objBinhLuan.IdBinhLuan).FirstOrDefault();

            DataProvider.Entities.Entry(objBinhLuanOld).CurrentValues.SetValues(objBinhLuan);
            DataProvider.Entities.SaveChanges();

            return true;
        }

        public bool Xoa(int Id)
        {
            BinhLuan objBinhLuan = LayChiTiet(Id);

            if (objBinhLuan != null)
            {
                DataProvider.Entities.BinhLuans.Remove(objBinhLuan);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }
    }
}