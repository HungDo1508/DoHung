using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class BaiVietBusiness
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="tuKhoa"></param>
       /// <param name="IdDanhMuc"></param>
       /// <returns></returns>
        public List<BaiViet> TimKiemThongTin(string tuKhoa ,string IdDanhMuc )
        {
            IQueryable<BaiViet> lstBaiViet = DataProvider.Entities.BaiViets;
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                lstBaiViet = lstBaiViet.Where(b => b.TieuDe.Contains(tuKhoa) || b.MoTa.Contains(tuKhoa) );
            }

            if (!string.IsNullOrEmpty(IdDanhMuc))
            {
                lstBaiViet = lstBaiViet.Where(b => b.IdDanhMuc != null && b.IdDanhMuc.Equals(IdDanhMuc));
            }


           return lstBaiViet.Where(x=> x.TrangThai ==true).OrderBy(a => a.TrangThai).ThenByDescending(s => s.IdBaiViet).ToList();
            //return lstBaiViet.OrderBy(s => s.TrangThai).ToList();
        }
        public List<BaiViet> TimKiemThongTinAD(string tuKhoa, string IdDanhMuc , string tenTacGia  , string trangThai, DateTime? start, DateTime? end)
        {
            IQueryable<BaiViet> lstBaiViet = DataProvider.Entities.BaiViets;
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                lstBaiViet = lstBaiViet.Where(b => b.TieuDe.Contains(tuKhoa) || b.MoTa.Contains(tuKhoa));
            }

            if (!string.IsNullOrEmpty(IdDanhMuc))
            {
                lstBaiViet = lstBaiViet.Where(b => b.IdDanhMuc != null && b.IdDanhMuc.Equals(IdDanhMuc));
            }
            if (!string.IsNullOrEmpty(tenTacGia))
            {
                lstBaiViet = lstBaiViet.Where(b => b.TacGia.Contains(tenTacGia));
            }
            if (!string.IsNullOrEmpty(trangThai))
            {
                if (trangThai == "true" || trangThai == "1")
                {
                    lstBaiViet = lstBaiViet.Where(b => b.TrangThai == true);
                }
                 if (trangThai == "false" || trangThai == "0")
                {
                    lstBaiViet = lstBaiViet.Where(b => b.TrangThai == false);
                }
            }
            if (start.HasValue && end.HasValue)
            {
                lstBaiViet = lstBaiViet.Where(x => x.NgayXuatBan > start && x.NgayXuatBan < end);
            }
            //lstBaiViet = lstBaiViet.Where(e => e.NgayXuatBan >= startDate && e.NgayXuatBan <= endDate);

            //return lstBaiViet.ToList();
            return lstBaiViet.OrderBy(a => a.TrangThai).ThenByDescending(s => s.IdBaiViet).ToList();
            //return lstBaiViet.OrderBy(s => s.TrangThai).ToList();
        }

        public List<BaiViet> LayDanhSach()
        {
            return DataProvider.Entities.BaiViets.OrderByDescending(s => s.IdBaiViet).ToList();
        }
       
        public BaiViet LayChiTiet(int? Id)
        {
            BaiViet objBaiViet = DataProvider.Entities.BaiViets.Where(s => s.IdBaiViet == Id).FirstOrDefault();

            return objBaiViet;
        }

        public bool ThemMoi(BaiViet objBaiViet)
        {
            if (objBaiViet != null)
            {
                DataProvider.Entities.BaiViets.Add(objBaiViet);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CapNhat(BaiViet objBaiViet)
        {
            //Lấy thông tin sửa ra
            BaiViet objBaiVietOld = DataProvider.Entities.BaiViets.Where(s => s.IdBaiViet == objBaiViet.IdBaiViet).FirstOrDefault();

            DataProvider.Entities.Entry(objBaiVietOld).CurrentValues.SetValues(objBaiViet);
            DataProvider.Entities.SaveChanges();

            return true;
        }
        public bool ChangeStatus(long id)
        {
            //Lấy thông tin sửa ra
           
           var user  = DataProvider.Entities.BaiViets.Find(id);
            user.TrangThai = !user.TrangThai;
            DataProvider.Entities.SaveChanges();
            return user.TrangThai;
        }
        public bool Xoa(int Id)
        {
            BaiViet objBaiViet = LayChiTiet(Id);

            if (objBaiViet != null)
            {
                DataProvider.Entities.BaiViets.Remove(objBaiViet);
                DataProvider.Entities.SaveChanges();
                return true;
            }

            return false;
        }
    }
}