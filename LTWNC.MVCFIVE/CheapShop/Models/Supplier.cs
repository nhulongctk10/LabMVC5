using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapShop.Models
{
   public class Supplier
    {
       [DisplayName("Mã NCC")]
       public int SupplierId { get; set; }

       [Display(Name = "Tên NCC"),StringLength(100)]
       public string Name { get; set; }

       [StringLength(1000)]
       [DisplayName("Mô tả")]
       [DataType(DataType.MultilineText)]
       public string Description { get; set; }

       [Required,StringLength(50)]
       [DisplayName("Tên đại diện")]
       public string ContactName { get; set; }

       [StringLength(20)]
       [DisplayName("Chức danh NĐD")]
       public string ContactTitle { get; set; }

       [Required,StringLength(200)]
       [DisplayName("Địa chỉ Cty")]
       public string Address { get; set; }  

       [DataType(DataType.EmailAddress)]
       public string Email { get; set; }

       [StringLength(20),RegularExpression(@"\d{3,4}-\d{3}-\d{4,5}")]
       public string Phone { get; set; }

       [StringLength(20)]
       public string Fax { get; set; }

       [StringLength(100),DataType(DataType.Url)]
       [DisplayName("Địa chỉ website")]
       public string HomePage { get; set; }     //địa chỉ trang web

       [DisplayName("Đã xóa")]
       public bool Actived { get; set; }        //đánh dấu xóa

       //Thuộc tính này dùng cho việc theo dõi việc cập nhật thông tin
       //    và sử dụng cho việc xử lý truy cập đồng thời

       [Timestamp]
       public byte[] RowVersion { get; set; }

       public virtual IList<Product> Products { get; set; }
    }
}
