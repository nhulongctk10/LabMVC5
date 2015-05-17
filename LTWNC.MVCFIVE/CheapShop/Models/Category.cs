using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "<b>Tên loại SP</b> bắt buộc nhập"), DisplayName("Tên loại SP"), StringLength(100,ErrorMessage = "<b>Tên loại SP</b> không vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "<b>Tên gọi khác</b> bắt buộc nhập"), StringLength(100, ErrorMessage = "<b>Tên gọi khác</b> không vượt quá hơn 100 ký tự")]
        [DisplayName("Tên gọi khác")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "<b>Mô tả</b> bắt buộch nập"), StringLength(1000, ErrorMessage = "<b>Mô tảP</b> không vượt quá 1000 ký tự")]
        [DisplayName("Mô tả")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(500,ErrorMessage = "Đường dẫn hình ảnh quá dài (<500  ký tự)")]
        [DisplayName("Đường dẫn hình ảnh")]
        [DataType(DataType.MultilineText)]
        public string IconPath { get; set; }

        [DisplayName("Đã xóa")]
        public bool Actived { get; set; }

        [DisplayName("Mã loại SP Cha")]
        public int? ParentId { get; set; }

        [DisplayName("Thứ tự xếp")]
        public int OrderNo { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //======================
        //Navigation Properties
        //======================

        public virtual Category Parent { get; set; }
        public virtual IList<Category> ChildCates  { get; set; }
        public virtual IList<Product> Products { get; set; }

    }
}