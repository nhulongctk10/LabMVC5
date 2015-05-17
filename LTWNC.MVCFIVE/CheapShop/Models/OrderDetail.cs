using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public class OrderDetail
    {
        [Key,Column(Order = 0),DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã hóa đơn")]
        public int OrderId { get; set; }

        [Key,Column(Order = 1),DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã SP")]
        public int ProductId { get; set; }

        [DisplayName("Giá bán")]
        public int Price { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Giảm giá")]
        public float Discount { get; set; }

        [StringLength(300)]
        [DisplayName("Ghi chú")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName("Thành tiền")]
        public int Total
        {
            get { return (int)Math.Round(Price * Quantity * (1 - Discount), 0); }
        }

        //===============================
        //Navigation Properties
        //===============================

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}