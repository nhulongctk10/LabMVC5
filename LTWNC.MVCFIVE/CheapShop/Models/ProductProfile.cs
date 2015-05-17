using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public class ProductProfile
    {
        [Display(Name = "Mã Profile")]
        public int ProductProfileId { get; set; }

        /// <summary>
        /// mã sp
        /// </summary>
        [Display(Name = "Mã SP")]
        public int ProductId { get; set; }

        /// <summary>
        /// số lượt xem
        /// </summary>
        [Display(Name = "Lượt xem")]
        public int ViewCount { get; set; }

        /// <summary>
        /// số  lượt bình chọn
        /// </summary>
        [Display(Name = "Số lượt bình chọn")]
        public int VoteCount { get; set; }

        /// <summary>
        /// tổng điểm
        /// </summary>
        [Display(Name = "Tổng điểm")]
        public int TotalScore { get; set; }

        /// <summary>
        /// Số lượng hàng đã bán
        /// </summary>
        [Display(Name = "Đã bán")]
        public int Sales { get; set; }     

        /// <summary>
        /// Điểm đánh giá trung bình
        /// </summary>
        [Display(Name = "Điểm đánh giá TB")]
        public float AvgScore 
        {
            get { return (float)Math.Round((decimal)TotalScore / VoteCount,2); }
        }

        public virtual Product Product{ get; set; }
    }
}