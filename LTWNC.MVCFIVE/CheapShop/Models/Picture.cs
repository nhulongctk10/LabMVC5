using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public class Picture
    {
        [DisplayName("Mã Hình")]
        public int PictureId { get; set; }

        [StringLength(150)]
        [DisplayName("Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề bắt buộc nhập")]
        public string Caption { get; set; }     //tieu de

        [StringLength(500)]
        [DisplayName("Đường dẫn")]
        public string Path { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int OrderNo { get; set; }        //thu tu hien thi

        [DisplayName("Đã xóa")]
        public bool Actived { get; set; }

        [DisplayName("Mã SP")]
        public int ProductId { get; set; }
    
        //=========================
        //Navigation Properties
        //=========================

        public virtual Product Product { get; set; }
    }
}