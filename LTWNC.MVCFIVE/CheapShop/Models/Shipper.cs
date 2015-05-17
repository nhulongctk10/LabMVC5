using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CheapShop.Models
{
    public class Shipper
    {
        [DisplayName("Mã công ty")]
        public int ShipperId { get; set; }

        [Required,StringLength(100)]
        [DisplayName("Tên công ty")]
        public string CompanyName { get; set; }

        [Required,StringLength(20)]
        [RegularExpression(@"\d{3,4}-\d{3}-\d{4,5}")]
        public string Phone { get; set; }

        [Required, StringLength(300)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
