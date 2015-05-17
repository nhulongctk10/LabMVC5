using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CheapShop.Core.DataAnnotations
{
    /// <summary>
    /// Thuộc tính quy định loại tập tin được phép upload
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class FileTypeAttribute : ValidationAttribute
    {
        private  readonly List<string> allowFileTypes;
        public FileTypeAttribute(string allowTypes)
            : base("Chỉ được phép upload các tập tin {FILE_TYPES}")
        {
            // Phân tách
            allowFileTypes = allowTypes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
        }

        public override bool IsValid(object value)
        {
            // Lấy đối tượng lưu tập tin được upload
            var upload = value as HttpPostedFileBase;

            // Nếu không có tập tin được post lên thì xem như không hợp lệ
            if (upload == null)
                return true;

            // Nếu có, kiểm tra loại tập tin có hợp lệ
            // Lấy phần mở rộng của tập tin
            var fileExt = Path.GetExtension(upload.FileName);

            if (!string.IsNullOrWhiteSpace(fileExt))
            {
                // Bỏ dấu chấm.
                fileExt = fileExt.Substring(1);

                // Trả về true nếu phần mở rộng nằm trong danh sách cho phép
                return allowFileTypes.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            // Nối các định dạng cho phép thành 1 chuổi
            var fileTypes = string.Join(", ", allowFileTypes);

            var errorMessage = base.ErrorMessageString;

            // Thay thế {FILE_TYPES} thành chuổi các định dạng
            if (errorMessage!=null && errorMessage.Contains("{FILE_TYPES}"))
                errorMessage = errorMessage.Replace("{FILE_TYPES}", fileTypes);
            return errorMessage;
        }


    }
}
