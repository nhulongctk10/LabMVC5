using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public enum ProductHistoryAction
    {
        Create,
        Delete,
        UpdateFull,
        UpdatePrice,
        UpdateQuantity
    }

    public class ProductHistory
    {
        [DisplayName("Mã")]
        public int Id { get; set; }

        [DisplayName("Mã SP")]
        public int ProductId { get; set; }

        [StringLength(128)]
        [DisplayName("Mã NV")]
        public string AccountId { get; set; }

        [DisplayName("Ngày giờ")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:c}")]
        public DateTime ActionTime { get; set; }

        [DisplayName("Thao tác")]
        public ProductHistoryAction HistoryAction { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("SP trước")]
        public string OriginalProduct { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thay đổi SP")]
        public string ModifiedProduct { get; set; }

        //=========================
        //Navigation Properties
        //=========================
        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
    }
}