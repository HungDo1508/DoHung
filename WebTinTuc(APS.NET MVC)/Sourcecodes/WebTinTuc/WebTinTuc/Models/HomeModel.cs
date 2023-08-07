using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class HomeModel
    {
        public BaiViet BaiVietss { get; set; }
       
        public List<BinhLuan> bl { get; set; }

        public BinhLuan comment { get; set; }
    }
}