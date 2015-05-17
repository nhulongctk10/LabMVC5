using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class CommentSeeder
    {
        public static void Seek(ShopDbContext context)
        {
            context.Comments.AddOrUpdate(new Comment[]
            {
                new Comment
                {
                    FullName = "Nguyen Van Phong",
                    Email = "phongnv@gmail.com",
                    Subject = "Mẹ và Bé",
                    Content = "hiện nay em đang bắt tay vào việc làm videos bằng việc tải bài hát và hình ảnh trên mạng về sau đó dùng phần mềm proshow để làm video nhưng những video của em đang nên toàn bị trùng khớp nội dung thứ 3 và nó thông báo như sau,Video của bạn có thể bao gồm nhạc được bên thứ ba sở hữu."+
                                "Video của bạn có sẵn và có thể phát.Thông tin chi tiết về bản quyền:“Son Tung M-TP-Khong Phai Dang Vua Dau-6161″, ghi âm được quản lý bởi:AdRev for Rights Holder"+
                                "em phải làm sao để khắc phục đc lỗi này ak",
                    PostedTime = new DateTime(2015,4,2),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Không sao đâu bạn, chỉ là gậy đó nặng hay nhẹ thôi, thường thì nếu view ít, mình sẽ không liên kết ở kênh dính, chỉ bật kiếm tiền để đó, bao giờ hết hạn gậy, thì mới liên kết lại",
                    ReplyTime = new DateTime(2015,4,3),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 12
                }, new Comment
                {
                    FullName = "Trần Việt Nam",
                    Email = "Namtv@gmail.com",
                    Subject = "Mẹ và Bé",
                    Content = "Sơn cho mình hỏi là mình có một kênh chưa liên kết Adsense nhưng kênh này lại bị dính 1 strike. Giờ mình muốn tạo liên kết với Adsense thì có ảnh hưởng gì tới các kênh khác không? Theo mình thì không vì nếu dính 3 strike thì cũng bị khóa luôn account đấy rồi. Nhờ bạn chỉ giúp nhé.Srr vì câu hỏi không liên quan đến nội dung thảo luận lắm.",
                    PostedTime = new DateTime(2011,3,22),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Bên Yeah 1 hình như hỗ trợ tốt đó bạn, có hỗ trợ trực tiếp luôn, và cũng có diễn đàn (cái này mình nhìn thấy, chứ mình không tham gia) bạn thử tham gia xem sao. Tuy nhiên bên đó không chấp nhận re-upload nhé.",
                    ReplyTime = new DateTime(2015,4,26),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 28
                }, new Comment
                {
                    FullName = "Le Van Dung",
                    Email = "dunglv@gmail.com",
                    Subject = "Thắc mắc",
                    Content = "sao mình cmt hỏi lại bị xóa nhỉ?",
                    PostedTime = new DateTime(2015,4,21),
                    Actived = false,
                    Status = CommentStatus.Unread,
                    ProductId =28
                }, new Comment
                {
                    FullName = "Nguyen Nhật Long",
                    Email = "longnn@gmail.com",
                    Subject = "Áo Khoác nữ",
                    Content = "em bị chặn toàn thế giới chỉ vì cài hình mình tải lên để hiển thị đầu, giờ em thay và bấm “tranh chấp bản quyền” được không? máy xử lý hay người ạ, nếu người vào xem kênh em thì bị band là cái chắc.",
                    PostedTime = new DateTime(2015,1,22),
                    Actived = false,
                    Status = CommentStatus.Unread,
                    ProductId = 14
                }, new Comment
                {
                    FullName = "Trần Văn Đưc Thịnh",
                    Email = "thinhtv@gmail.com",
                    Subject = "Áo Khoác nữ",
                    Content = "sao em không gắn được quảng cáo vào video vậy bác",
                    PostedTime = new DateTime(2015,2,9),
                    Actived = false,
                    Status = CommentStatus.Unread,
                    ProductId = 12
                }, new Comment
                {
                    FullName = "Lê Thị Thúy Hồng",
                    Email = "hoangltt@gmail.com",
                    Subject = "Áo Khoác nữ",
                    Content = "Bạn cho mình hỏi, không biết tại sao có những video trên youtube rõ ràng là người ta reup(họ kiếm tiền được) nhưng khi mình lấy chính video đó up lại để kiếm tiền thì youtube không cho nữa nhỉ "+
                                "Video của bạn có sẵn và có thể phát.Thông tin chi tiết về bản quyền:“Son Tung M-TP-Khong Phai Dang Vua Dau-6161″, ghi âm được quản lý bởi:AdRev for Rights Holder"+
                                "em phải làm sao để khắc phục đc lỗi này ak",
                    PostedTime = new DateTime(2015,9,3),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Không sao đâu bạn, chỉ là gậy đó nặng hay nhẹ thôi, thường thì nếu view ít, mình sẽ không liên kết ở kênh dính, chỉ bật kiếm tiền để đó, bao giờ hết hạn gậy, thì mới liên kết lại",
                    ReplyTime = new DateTime(2015,1,3),
                    AccountId = "5c2619cf-1f0c-4d34-9749-6b8ac7c86ed3",
                    ProductId = 14
                }, new Comment
                {
                    FullName = "Nguyen Đình Phú",
                    Email = "phund@gmail.com",
                    Subject = "Bộ đồ thể thao nam nử",
                    Content = "Pin = Tab thu gọn là sao nhỉ ?Lần đầu comment làm quen",
                    PostedTime = new DateTime(2015,1,29),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Cái tab ở Chrome đó bạn, bạn bấm chuột phải vào tab thì có chữ pin tab hay dùng tiếng việt hình như là Thu gọn. Cái này giúp cho việc tránh tắt nhầm tab đang uploads video. hihi. rất vui được làm quen với bạn",
                    ReplyTime = new DateTime(2015,1,30),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 15
                }, new Comment
                {
                    FullName = "Jam Việt",
                    Email = "vietj@gmail.com",
                    Subject = "Bộ đồ thể thao nam nử",
                    Content = "Lâu lâu sang nhà bạn comment, kiếm cái backlink nofollow :D thía mà bạn lại vừa nofollow lại vừa redirect, theson.net/url/jamviet.com => Buồn ớ ",
                    PostedTime = new DateTime(2015,3,24),
                    Actived = false,
                    Status = CommentStatus.Unread,
                    ReplyContent = "Anh đọc bài này nhé, http://theson.net/lamseo/theson-net-khong-chia-se-backlink/ cảm ơn anh đã ghé thăm.",
                    ReplyTime = new DateTime(2015,3,26),
                    AccountId = "5c2619cf-1f0c-4d34-9749-6b8ac7c86ed3",
                    ProductId = 17
                }, new Comment
                {
                    FullName = "Nguyễn Huy Hoàng",
                    Email = "hoangnh@gmail.com",
                    Subject = "Mẹ và Bé",
                    Content = "Anh ơi, Em đăng video lên Youtube rồi vào phần chỉnh sửa âm thanh. Nó đưa ra nhạc, em thắc mắc chỗ này: Nó hiện danh sách và ghi ” Nhạc không có quảng cáo dành cho video của bạn ” , còn 1 danh sách ở dưới thì ghi ” Các bài hát hỗ trợ quảng cáo ” Vậy thì chọn bài hát trong danh sách nào anh?",
                    PostedTime = new DateTime(2012,3,21),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Có người dùng chế độ phát Live và lưu lại luôn như thể thời sự của VTVgo đó em :) (cái mail của em dị nhỉ??)",
                    ReplyTime = new DateTime(2012,3,22),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 16
                }, new Comment
                {
                    FullName = "Vietnam Tours",
                    Email = "Tours@gmail.com",
                    Subject = "Thắc mắc giá",
                    Content = "A thế sơn có link download 2 tool đó không ah ! cho em xin link anh nhé ! thanks",
                    PostedTime = new DateTime(2012,2,21),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Bạn lên google hỏi, cái này cũng phải chia sẻ nữa sao !?",
                    ReplyTime = new DateTime(2012,2,22),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 12
                }, new Comment
                {
                    FullName = "Lê Văn Tuấn Anh",
                    Email = "anhlv@gmail.com",
                    Subject = "Ship hàng",
                    Content = "Anh ơi file em làm ra là file.avi vậy khi đăng lên youtube em có cần phải đổi đuôi thành mp4 hok anh ? mà em dùng proshow producer , vậy làm thế nào để làm cho video hd có dung lượng thấp ạ ?",
                    PostedTime = new DateTime(2010,4,4),
                    Actived = false,
                    Status = CommentStatus.Vilolate,
                    ReplyContent = "Không cần đổi thành MP4 ở proshow file avi với tỷ lệ 1280×720 là file HD rồi",
                    ReplyTime = new DateTime(2010,4,5),
                    AccountId = "638bbe82-b838-45e4-8f01-4aa467a95092",
                    ProductId = 16
                }
            });

            context.SaveChanges();
        }
    }
}