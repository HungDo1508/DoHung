using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTinTuc.Models
{
    public class DataProvider
    {
        /// <summary>
        /// Khai báo 1 thuộc tính để làm việc với db bằng EF
        /// </summary>
        private static QuanLyBaiVietEntities _Entities = null;

        public static QuanLyBaiVietEntities Entities
        {
            get
            {
                if (_Entities == null)
                {
                    _Entities = new QuanLyBaiVietEntities();
                }

                return _Entities;
            }
        }
    }
}