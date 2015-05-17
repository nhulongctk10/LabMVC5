using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace CheapShop.Models
{
    public enum OrderStatus
    {
        New,
        Cancelled,
        Approved,
        Shipping,
        Returned,
        Success
    }

    public class Order
    {
        [DisplayName("Mã đơn hàng")]
        public int OrderId { get; set; }
        
        [StringLength(128)]
        [DisplayName("Mã khách hàng")]
        public string CustomerId { get; set; }

        [StringLength(128)]
        [DisplayName("Mã nhân viên")]
        public string EmployeeId { get; set; }

        [DisplayName("Ngày đặt")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public DateTime? OrderDate { get; set; }

        [DisplayName("Ngày yêu cầu giao")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:c}")]
        public DateTime? RequiredDate { get; set; }

        [DisplayName("Ngày giao")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{c:0}")]
        public DateTime? ShipDate { get; set; }

        [DisplayName("Phí vận chuyển")]
        public int Freight { get; set; }

        [DisplayName("Cty Vận chuyển")]
        public int? ShipVia { get; set; }

        [Required,StringLength(50)]
        [DisplayName("Tên người nhận")]
        public string ShipName { get; set; }

        [Required,StringLength(300)]
        [DisplayName("Địa chỉ giao hàng")]
        public string ShipAddress { get; set; }

        [Required,StringLength(20)]
        [DisplayName("SĐT")]
        [RegularExpression(@"\d{3-4}-\d{3}-\d{4-5}")]
        public string ShipTel { get; set; }

        [DisplayName("Trạng thái")]
        public OrderStatus Status { get; set; }

        [StringLength(500)]
        [DisplayName("Ghi chú")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        //==============================
        //Navigation Properties
        //==============================


        public virtual Account Employee { get; set; }
        public virtual Account Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }


    }
}