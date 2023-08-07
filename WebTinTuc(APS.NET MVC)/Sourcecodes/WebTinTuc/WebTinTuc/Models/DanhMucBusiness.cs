using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class DanhMucBusiness
    {
        public List<DanhMucViewModel> LayDanhSach()
        {
            List<DanhMucViewModel> lstDanhMuc = (from item in DataProvider.Entities.DanhMucs
                                                 select new DanhMucViewModel()
                                                 {
                                                     IdDanhMuc = item.IdDanhMuc != null ? item.IdDanhMuc : "",
                                                     TenDanhMuc = item.TenDanhMuc
                                                 }).ToList();

            return lstDanhMuc;
        }
    }
}