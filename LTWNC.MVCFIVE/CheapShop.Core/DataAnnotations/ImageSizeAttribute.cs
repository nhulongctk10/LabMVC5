using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CheapShop.Core.DataAnnotations
{
    /// <summary>
    /// Thuộc tính quy định kích thước tối đa của tập tin
    /// hình ảnh được phép upload
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method)]
    public class ImageSizeAttribute : ValidationAttribute
    {
        private ImageValidationResult ivResult = ImageValidationResult.Valid;

        private static string[] mimeTypes =
        {
            "image/jpg","image/jpeg","image/pjpeg","image/gif",
            "image/x-png","image/png","image/bmp","image/x-icon",
            "image/x-tiff","image/tiff"
        };

        private static string[] imageExt =
        {
            ".jpg",".jpeg",".gif",".png",".bmp",".icon",".tiff"
        };

        /// <summary>
        /// Chiều rộng tối đa, tính theo pixel
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Chiều cao tối đa, tính theo pixel
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Sử dụng {WIDTH} và {HEIGHT} để đánh dấu vị trí
        /// sẽ thay thế bởi độ rộng và chiều cao tối đa
        /// </summary>
        public ImageSizeAttribute()
            : base("Kích thước hình vượt quá cỡ {WIDTH}x{HEIGHT}")
        {
        }


        /// <summary>
        /// Kiểm tra kiểu nội dung của tập tin được upload
        /// có phải là kiểu nọi dung hình anh
        /// </summary>
        /// <param name="upload">Tập tin được upload</param>
        /// <returns>
        /// Trả về false nếu không đúng định dạng nội dung
        /// của các loại tập tin hình ảnh, true nếu ngược lại
        /// </returns>
        private bool CheckMineTypes(HttpPostedFileBase upload)
        {
            // Lấy kiểu nội dung của tập tin được upload
            var contentType = upload.ContentType.ToLower();

            // Nếu kiểu nội dung không thuộc kiểu hình ảnh
            if (!mimeTypes.Contains(contentType))
            {
                // Thì đánh dấu MIME type không hợp lệ
                ivResult = ImageValidationResult.InvalidMimeType;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra phần tên mở rộng của tập tin nằm trong 
        /// danh sách những loại hình ảnh được phép upload?
        /// </summary>
        /// <param name="upload">Tập tinh được upload</param>
        /// <returns>
        /// Trả về false nếu tên mở rộng không nằm trong danh 
        /// sách các định dạng được phép upload, true nếu ngược lại
        /// </returns>
        private bool CheckFileExtendsion(HttpPostedFileBase upload)
        {
            // Lấy phần mở rộng của tập tin
            var fileExt = Path.GetExtension(upload.FileName);


            // Nếu có phần tên mở rộng
            if (!string.IsNullOrWhiteSpace(fileExt))
            {
                // Trả về true nếu phần mở rộng nằm trong danh sách cho phép
                if (imageExt.Contains(fileExt, StringComparer.OrdinalIgnoreCase))
                    return true;
            }

            // Đánh dấu định dạng file không hợp lệ
            ivResult = ImageValidationResult.NotAllowedType;
            return false;
        }


        private bool CheckImageSize(HttpPostedFileBase upload)
        {
            // Nếu không thể đọc được nội dung thì gán ko hợp lệ
            if (!upload.InputStream.CanRead)
            {
                ivResult = ImageValidationResult.InvalidHeader;
                return false;
            }
            try
            {
                // Tạo hình ảnh từ luồng upload
                using (var image = Image.FromStream(upload.InputStream))
                {
                    // Kiểm tra kích cỡ ảnh có vượt quá cỡ cho phép
                    // Nếu có, trả về false
                    if (image.Width > Width || image.Height > Height)
                    {
                        ivResult = ImageValidationResult.OverSize;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                ivResult = ImageValidationResult.InvalidHeader;
                return false;
            }
        }

        public override bool IsValid(object value)
        {
            // Lấy đối tượng lưu tập tin được upload
            var upload = value as HttpPostedFileBase;

            // Nếu không có tập tin được post lên thì xem như không hợp lệ
            if (upload == null) return true;

            // Lần lượt thực hiện các thao tác kiểm tra
            bool valid = true;

            // Kiểm tra mime types
            valid = CheckMineTypes(upload);

            // Kiểm tra phần đuôi mở rộng
            if (valid)
                valid = CheckFileExtendsion(upload);

            return valid;
        }

        public override string FormatErrorMessage(string name)
        {
            var errorMessage = base.ErrorMessageString;
            switch (ivResult)
            {
                case ImageValidationResult.InvalidHeader:
                    return "Không thể đọc được nội dung file ảnh.";
                case ImageValidationResult.InvalidMimeType:
                case ImageValidationResult.NotAllowedType:
                    return "Hệ thống không hổ trợ định dạng ảnh này";
                case ImageValidationResult.OverSize:
                    if (errorMessage != null)
                    {
                        if (errorMessage.Contains("{WIDTH}"))
                            errorMessage = errorMessage.Replace("{WIDTH}", Width.ToString());
                        if (errorMessage.Contains("{HEIGHT}"))
                            errorMessage = errorMessage.Replace("{HEIGHT}", Height.ToString());
                    }
                    return errorMessage;
                default:
                    return errorMessage;
            }
        }
    }
}
