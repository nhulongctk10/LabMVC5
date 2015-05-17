using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapShop.Core.DataAnnotations
{
   public enum ImageValidationResult
    {
       // Kiểu nội dung tập tin không phải là ảnh
       InvalidMimeType,

       // Định dạng ảnh không được phép upload
       NotAllowedType,

       // Tập tin không phải là tập tin ảnh
       InvalidHeader,

       // Ảnh có kích thước quá quy định
       OverSize,

       // Hợp lệ
       Valid
    }
}
