using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CheapShop.Models
{
    public class Product
    {
        [DisplayName("Mã SP")]
        public int ProductId { get; set; }

        [Required, StringLength(100), DisplayName("Tên SP")]
        public string Name { get; set; }

        [Required,StringLength(100)]
        [DisplayName("Tên khác")]
        public string Alias { get; set; }

        [Required,StringLength(300)]
        [Display(Name = "Ảnh Thumbnail")]
        public string Thumbnail { get; set; }       //ảnh thumbnail

        [Required,StringLength(20)]
        [DisplayName("Số hiệu SP")]
        public string ProductCode { get; set; }     //số hiệu sản phẩm

        [StringLength(500)]
        [DisplayName("Giới thiệu")]
        [DataType(DataType.MultilineText)]
        public string ShortIntro { get; set; }

        [Column(TypeName = "ntext"), AllowHtml]
        [DisplayName("Mô tả")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(50)]
        [DisplayName("Đơn vị")]
        public string QtyPerUnit { get; set; }

        [DisplayName("Giá")]
        public int Price { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [Range(0, 1),DisplayFormat(DataFormatString = "{0:P1}")]
        [DisplayName("Giảm giá")]
        public float Discount { get; set; }

        [DisplayName("Mã NCC")]
        public int SupplierId { get; set; }     //id Nhà cung cấp

        [DisplayName("Đã xóa")]
        public bool Actived { get; set; }       //Đánh dấu đã xóa

        [Timestamp,JsonIgnore]
        public byte[] RowVersion { get; set; }


        //====================================
        // Navigation Properties
        //====================================
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }
        [JsonIgnore]
        public virtual IList<Category> Category { get; set; }
        [JsonIgnore]
        public virtual IList<OrderDetail> OrderDetail { get; set; }
        [JsonIgnore]
        public virtual IList<Comment> Comments { get; set; }
        [JsonIgnore]
        public virtual IList<Picture> Pictures { get; set; }
        [JsonIgnore]
        public virtual IList<ProductHistory> ProductHistories { get; set; }
        [JsonIgnore]
        public virtual ProductProfile ProductProfiles { get; set; }
    }
}