using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CheapShop.Core.DataAnnotations
{
   
    /// <summary>
    /// Thuộc tính quy định dung lượng tối đa của tập tin
    /// Được phép upload lên Server
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method)]
    public class FileSizeAttribute:ValidationAttribute
    {
        private readonly int maxSize;

        public FileSizeAttribute(int maxSize):base("Dung lượng tập tin không được quá {MAXSIZE} MB")
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            var upload = value as HttpPostedFileBase;
            if (upload == null) return true;

            return upload.ContentLength < maxSize*1024*1024;
        }

        public override string FormatErrorMessage(string name)
        {
            var errorMessage = base.ErrorMessageString;

            if (errorMessage!=null && errorMessage.Contains("{MAXSIZE}"))
            {
                errorMessage = errorMessage.Replace("{MAXSIZE}", maxSize.ToString());
            }
            return errorMessage;
        }
    }
}
