using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheapShop.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("Account"), StringLength(128)]
        [DisplayName("Mã TK")]
        public string AccountId { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Họ và tên lót")]
        public string FirstName { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Tên")]
        public string LastName { get; set; }

        [StringLength(50)]
        [DisplayName("Chức vụ")]
        public string JobPosition { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày sinh")]
        public DateTime? BirthDate { get; set; }

        [StringLength(300)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(500)]
        [DisplayName("Hình đại diện")]
        public string Picture { get; set; }

        [StringLength(1000)]
        [DisplayName("Ghi chú")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName("Tên đầy đủ")]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public virtual Account Account { get; set; }
    }
}