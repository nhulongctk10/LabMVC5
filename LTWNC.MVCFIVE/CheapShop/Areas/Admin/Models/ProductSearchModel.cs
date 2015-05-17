using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheapShop.Areas.Admin.Models
{
    public class ProductSearchModel
    {
        // Từ khóa người dùng nhập vào để tìm theo
        // tên SP, giới thiệu hay mô tả chi tiết.
        public string Keyword { get; set; }

        // Số TT trang thái hiện tại và số mẩu tin / trang
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        // Trạng thái của sản phẩm
        public bool? Actived { get; set; }
    }
}