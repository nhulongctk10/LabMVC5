using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheapShop.Core.DataAnnotations;

namespace CheapShop.Areas.Admin.Models
{
    [Bind(Exclude = "Categories,Suppliers")]
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Chưa nhập tên SP"), StringLength(100), Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên định danh"), StringLength(100), Display(Name = "Tên định danh")]
        [Remote("CheckUniqueAlias", "Product", AdditionalFields = "ProductId", ErrorMessage = "{0} này đã được sử dụng cho sản phẩm khác")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Chưa nhập số hiệu SP"), StringLength(20), Display(Name = "Số hiệu sản phẩm")]
        [Remote("CheckUniqueCode", "Product", AdditionalFields = "ProductId", ErrorMessage = "{0} này đã được sử dụng cho sản phẩm khác")]
        public string ProductCode { get; set; }

        [Display(Name = "Hình đại diện")]
        [FileType("jpg,jpeg,png,gif"), FileSize(1)]
        [ImageSize(Width = 400, Height = 500)]
        public HttpPostedFileBase Upload { get; set; }

        [StringLength(500), DataType(DataType.MultilineText)]
        [Display(Name = "Giới thiệu")]
        public string ShortIntro { get; set; }


        [AllowHtml, Display(Name = "Mô tả chi tiết")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(50), Display(Name = "Đơn vị tính")]
        public string QtyPerUnit { get; set; }

        [Display(Name = "Giá bán"), Range(1000, 10000000, ErrorMessage = "Giá bán phải nằm trong khoảng (1000 - 10000000)")]
        public int Price { get; set; }

        [Display(Name = "Số lượng"), Range(0, 100000, ErrorMessage = "Số lượng phải nằm trong khoảng (0 -100000)")]
        public int Quantity { get; set; }

        [Range(0, 100000, ErrorMessage = "Giảm giá phải nằm trong khoảng (0 -100000)"), Display(Name = "Giảm giá")]
        public float Discount { get; set; }

        [Display(Name = "Nhà cung cấp")]
        [Required(ErrorMessage = "Chưa chọn nhà cung cấp")]
        public int SupplierId { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Actived { get; set; }

        // Lưu danh sách mã các món hàng được chọn
        public int[] SelectedCategories { get; set; }

        // Danh sách nhóm mặt hàng và nhà cung cấp
        public MultiSelectList Categories { get; set; }
        public SelectList Suppliers { get; set; }
    }
}