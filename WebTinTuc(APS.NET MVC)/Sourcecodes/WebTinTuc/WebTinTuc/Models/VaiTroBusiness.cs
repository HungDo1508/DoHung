using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class VaiTroBusiness
    {
        public List<VaiTroViewModel> LayDanhSach()
        {
            List<VaiTroViewModel> lstVaiTro = (from item in DataProvider.Entities.VaiTroes
                                                 select new VaiTroViewModel()
                                                 {
                                                     IdVaiTro = item.IdVaiTro != null ? item.IdVaiTro : "",
                                                     TenVaiTro = item.TenVaiTro
                                                 }).ToList();

            return lstVaiTro;
        }
    }
}