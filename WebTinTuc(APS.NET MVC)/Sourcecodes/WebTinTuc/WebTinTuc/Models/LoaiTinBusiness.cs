using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class LoaiTinBusiness
    {
        public List<LoaiTinViewModel> LayDanhSach()
        {
            List<LoaiTinViewModel> lstLoaiTin = (from item in DataProvider.Entities.LoaiTins
                                             select new LoaiTinViewModel()
                                             {
                                                 IdLoaiTin = item.IdLoaiTin != null ? item.IdLoaiTin : "",
                                                 TenLoaiTin = item.TenLoaiTin
                                             }).ToList();

            return lstLoaiTin;
        }
    }
}