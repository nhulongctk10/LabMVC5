using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public enum CommentStatus
    {
        Unread,
        Vilolate        //Vi pham noi quy
    }
    public class Comment
    {
        [DisplayName("Mã bình luận")]
        public int CommentId { get; set; }

        [StringLength(50),Required]
        [DisplayName("Họ tên người gửi")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress),StringLength(100),Required]
        public string Email { get; set; }

        [StringLength(100),Required]
        [DisplayName("Tiêu đề")]
        public string Subject { get; set; }

        [Required,StringLength(1000)]
        [DisplayName("Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayName("Ngày giờ gửi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? PostedTime { get; set; }

        [DisplayName("Đã xóa")]
        public bool Actived { get; set; }

        [DisplayName("Trạng thái")]
        public CommentStatus Status { get; set; }

        [StringLength(1000)]
        [DisplayName("Nội dung trả lời")]
        [DataType(DataType.MultilineText)]
        public string ReplyContent { get; set; }

        [DisplayName("Ngày giờ TL")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ReplyTime { get; set; }

        [StringLength(128)]
        [DisplayName("Mã NV trả lời")]
        public string AccountId { get; set; }       //Mã nhân viên trả lời

        [DisplayName("Mã SP")]
        public int ProductId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //=====================
        //Navigation Properties
        //=====================

        public virtual Account Replier{ get; set; }
        public virtual Product Product { get; set; }

    }
}