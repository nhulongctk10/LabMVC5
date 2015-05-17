using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.DAL;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class ProductSeeder
    {
        public static void Seed(ShopDbContext context)
        {
            context.Products.AddOrUpdate(p => p.Name,
                new Product
                {
                    Name = "Đầm body lệch vai 0403",
                    Alias = "Dam-body-lech-vai",
                    ShortIntro ="Đầm body lệch vai 0403 sang trọng tôn lên vóc dáng quyến rũ cho phái đẹp trị giá 250.000 VNĐ nay chỉ còn 150.000 VNĐ.",
                    Description = "Thiết kế tinh tế giúp bạn gái tôn body đẹp, khoe đôi chân thon dài." +
                                  "Các dường nhún tạo sự thon gọn và ôm sát body quyến rũ cho phái đẹp. " +
                                  "Chất liệu thun co giãn, không xù lông, thấm hút mồ hôi, co giãn 4 chiều cho bạn cảm giác vô cùng thoải mái." +
                                  "Có thể phối với 1 số trang sức và phụ kiện khác cho bạn thật sang trọng và nổi bật, phù hợp với nhiều sự kiện khác nhau." +
                                  "Màu sắc: đen Có 2 size M & L dành cho các bạn lựa chọn phù hợp với vóc dáng",
                    Price = 150,
                    Actived = false,
                    QtyPerUnit = "Cái",
                    Quantity = 10,
                    SupplierId = 1,
                    ProductCode="52778",
                    Thumbnail="~/ProductImages/timthumb001.jpg"
                }, new Product
                {
                    Name = "Đầm Stella 1203",
                    Alias = "Dam-body-lech-vai",
                    ShortIntro = "Đầm Stella 1203 sang trọng duyên dáng trị giá 450.000 VNĐ nay chỉ còn 265.000 VNĐ.",
                    Description = "Thiết kế tinh tế giúp bạn gái tôn body đẹp, khoe đôi chân thon dài." +
                                  "Các dường nhún tạo sự thon gọn và ôm sát body quyến rũ cho phái đẹp. " +
                                  "Dễ dàng phối cùng phụ kiện khác nhau. Chất liệu: thun poly Màu sắc: Đỏ - Đen Có 2 size M&L dành cho các bạn lựa chọn tùy theo vóc dáng.",
                    Price = 150,
                    Actived = false,
                    Discount = 0,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode="523278",
                    Thumbnail="~/ProductImages/damStella003.jpg"
                }, new Product
                {
                    Name = "Bộ đồ dạo phố Hàn Quốc",
                    Alias = "Bo-do-dao-pho-Han-Quoc",
                    ShortIntro ="Bộ đồ dạo phố Hàn Quốc sang trọng, dễ thương trị giá 250.000 VNĐ nay chỉ còn 199.000 VNĐ.",
                    Description ="Bộ đồ dạo phố Hàn Quốc sang trọng, dễ thương là sự lựa chọn vô cùng hoàn hảo dành cho các bạn gái." +
                        "Bộ đồ dạo phố Hàn Quốc với thiết kế áo rời quần, cách điệu, đơn gainr và sang trọng. Chất liệu cao cấp với đường may tinh tế, tỉ mỉ khéo léo, màu sắc ngọt ngào, thời trang. " +
                        "Bộ đồ dạo phố Hàn Quốc mang lại nét tự tin, thanh lịch cho các bạn gái thêm phần dễ thương khi đi dạo phố. " +
                        "Chất liệu: Cát giấy Màu sắc: Tím - Hồng - Xanh Có 2 size M&L để các bạn lựa chọn phù hợp với vóc dáng của mình",
                    Price = 199,
                    Actived = false,
                    Discount = 0.3f,
                    QtyPerUnit = "Cái",
                    Quantity = 22,
                    SupplierId = 2,
                    ProductCode="43321",
                    Thumbnail="~/ProductImages/bododaopho001.jpg"
                }, new Product
                {
                    Name = "Áo khoác nữ hoodie 78",
                    Alias = "Ao-khoac-nu-hoodie",
                    ShortIntro ="Áo khoác nữ hoodie 78 trẻ trung, dễ thương trị giá 250.000 VNĐ nay chỉ còn 155.000 VNĐ",
                    Description ="Áo khoác nữ hoodie 78 trẻ trung, dễ thương mang lại nét tinh nghịch, đáng yêu cho các bạn trẻ." +
                        "Áo khoác nữ hoodie 78 thiết kế có nón thời trang, năng động, tay dài, form dài vừa ôm vừa người mặc, bo vạt áo và tay áo giúp trang phục thêm phần gọn gàng và năng động. Thân áo trươc in hình họa tiết số và ngôi sao ngộ nghĩnh đáng yêu." +
                        "Áo khoác nữ hoodie 78 là sự lựa chọn phù hợp cho các nàng năng động, xinh xắn.Có thể kết hợp cùng nhiều trang phục và phụ kiện khác.Chất liệu: thun nỉ Màu sắc:  Cam - Xanh  Freesize cho các bạn gái từ 50kg trở xuống (tùy chiều cao)",
                    Price = 155,
                    Actived = false,
                    QtyPerUnit = "Cái",
                    Quantity = 10,
                    SupplierId = 2,
                    ProductCode="44221",
                    Thumbnail="~/ProductImages/aokhoacnuhoodie.jpg"
                }, new Product
                {
                    Name = "Áo thun cặp nam nữ họa tiết",
                    Alias = "Ao-thun-cap-nam-nu-hoa-tiet",
                    ShortIntro ="Một chiếc áo cặp nam nữ đẹp cho tình yêu của bạn thêm nở hoa và đầy sắc hồng cùng Áo thun cặp nam nữ họa tiết trị giá 270.000 VNĐ nay chỉ còn 170.000 VNĐ.",
                    Description ="Áo thun cặp nam nữ họa tiết được làm từ chất thun mềm mại, thoáng mát, thấm hút mồ hôi tốt cho bạn thoải mái khi cử động." +
                        "Áo thun cặp nam nữ họa tiết form áo đơn giản với cổ tròn, tay ngắn và thân áo suông ôm vừa phải giúp khoe khuyết điểm hiệu quả, dễ dàng cho bạn trong việc kết hợp cùng quần jean hay short lửng cá tính." +
                        "Chất liệu thun co giãn, không xù lông, thấm hút mồ hôi, co giãn 4 chiều cho bạn cảm giác vô cùng thoải mái." +
                        "Áo thun cặp nam nữ họa tiết thiết kế mới lạ với sự khác nhau về màu sắc nhưng cùng kiểu dáng tượng trưng cho khi yêu nhau mỗi người một cách nghĩ nhưng đều suy nghĩ cho đối phương trước, gắn kết tình cảm sâu đậm ." +
                        "Giá áp dụng cho 2 áo nam nữ.Freesize cho nữ dưới 52kg, nam dưới 68kg.",
                    Price = 170,
                    Actived = false,
                    QtyPerUnit = "Cái",
                    Quantity = 44,
                    SupplierId = 2,
                    ProductCode="33215",
                    Thumbnail="~/ProductImages/aothunnamnu001.jpg"
                }, new Product
                {
                    Name = "Bộ đồ thể thao khoét lưng",
                    Alias = "Bo-do-the-thao-khoet-lung",
                    ShortIntro ="Bộ đồ thể thao khoét lưng năng động, trẻ trung trị giá 300.000 VNĐ nay chỉ còn 195.000 VNĐ.",
                    Description ="Bộ đồ thể thao khoét lưng năng động, trẻ trung là sự lựa chọn vô cùng hoàn hảo dành cho các bạn nữ thích phong cách thể thao và quyến rũ." +
                        "Bộ đồ thể thao khoét lưng thiết kế áo rời quần, chất liệu cao cấp, đường may chi tiết, cẩn thận, chắc chắn, thoải mái vận động, di chuyển, màu sắc tươi trẻ, họa tiết lạ mắt, áo khoét lưng lạ mắt, gợi cảm và dễ thương." +
                        "Bộ đồ thể thao khoét lưng mang lại sự tự tin, nét trẻ trung, nổi bật và phong cách thời trang cá tính, khỏe khoắn cho các bạn gái." +
                        "Chất liệu: Thun nhung Hàn Quốc Màu sắc:  Xanh - Đỏ Có 2 size cho các bạn lựa chọn.",
                    Price = 195,
                    Actived = false,
                    Discount = 0.4f,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode="66332",
                    Thumbnail="~/ProductImages/bodothethao001.jpg"
                }, new Product
                {
                    Name = "Bộ 3 tã quần bé trai 2 gói XL24 + 1 gói XXL10 MamyPoko",
                    Alias = "Bo-ta-quan-be-trai-2 goi",
                    ShortIntro ="Tã quần 2 gói XL24 + 1 gói XXL10 Trẻ trên 12kg Chất liệu sợi bông mềm mại, thấm hút",
                    Description = "Việc chăm sóc bé giờ đây đã trở nên dễ dàng và hiệu quả hơn nhờ sự xuất hiện của tã quần MamyPoko. Được sản xuất dựa trên công nghệ tiên tiến, tã có khả năng thấm hút cực nhanh, đồng thời chống tràn và thấm ngược, mang lại cho bé cảm giác thoải mái suốt ngày dài cũng như khi đi ngủ. Ngoài sợi vải mềm mại cấu tạo nên tã đem đến sự êm ái và tuyệt đối an toàn, không ảnh hưởng đến làn da non nớt của bé. Với tã quần MamyPoko, những cuộc vui của bé hẳn sẽ không còn bị gián đoạn." +
                        "Được làm từ chất liệu cao cấp theo công nghệ của Nhật Bản, sản phẩm rất an toàn cho sức khỏe của bé khi sử dụng." +
                        "Độ thấm hút cao cùng với việc được bổ sung thêm 1 lớp vải đặc biệt không cho thấm ngược giúp giữ cho da của bé được khô ráo trong thời gian dài." +
                        "Lõi bông mềm mại với lớp siêu dẫn thấm nhanh chóng thấm hút toàn bộ chất lỏng, cùng màng siêu thở giúp cho da bé luôn khô thoáng. Vách chống tràn kép 2 bên cho trẻ tự do vận động hay ngủ suốt đêm mà không tràn ra ngoài." +
                        "Chất liệu khử mùi, khử trùng, chống hăm da, và cung cấp cho da độ ẩm cần thiết của tã sẽ tăng cường bảo vệ làn da non nớt của bé." +
                        "Đường thun bên hông có thể xé được giúp dễ dàng cởi bỏ khi quần bẩn. Việc thay tã cho bé không còn chiếm quá nhiều thời gian của mẹ nữa. Sản phẩm được đóng gói bộ 3 túi tã giấy sẽ tiết kiệm thời gian cho mẹ khi mua sắm. Mẹ sẽ có nhiều thời gian hơn để chăm sóc bản thân và gia đình bé nhỏ của mình.",
                    Price = 529,
                    Actived = false,
                    Discount = 0.32f,
                    QtyPerUnit = "Cái",
                    Quantity = 90,
                    SupplierId = 4,
                    ProductCode="45231",
                    Thumbnail="~/ProductImages/bo-3-ta-quan-be-trai-2-goi-xl24.jpg"
                }, new Product
                {
                    Name = "Combo 3 Bộ Đồ Mặc Nhà Cho Bé",
                    Alias = "Combo-Bo-Do-Mac-Nha-Cho-Be",
                    ShortIntro ="Combo 3 Bộ Đồ Mặc Nhà Cho Bé – Gồm Áo 3 Lỗ, Quần Short Mát Mẻ, Chất Liệu Thấm Hút Mồ Hôi Tốt – Giúp Bé Luôn Thoải Mái Trong Ngày Hè. Giá 189.000 VNĐ, Còn 110.000 VNĐ, Giảm 42%. Chỉ Có Tại Hotdeal.vn!",
                    Description =" Combo 3 bộ đồ mặc nhà cho bé gồm quần short mát mẻ, áo 3 lỗ khỏe khoắn, rất thích hợp với thời tiết ngày hè nóng nực."+
                                "Chất liệu thun co giãn và thấm hút mồ hôi tốt, tạo cho bé cảm giác thoải mái khi ngủ, khi chơi đùa, vận động…"+
                                "Màu trắng in họa tiết ngộ nghĩnh, giúp bé trông xinh xắn và đáng yêu hơn rất nhiều."+
                                "Là trang phục mặc nhà dành cho cả bé trai và bé gái."+
                                "Trọng lượng gói hàng cả bao bì: 265 gram",
                    Price = 189,
                    Actived = false,
                    Discount = 0.42f,
                    QtyPerUnit = "Cái",
                    Quantity = 32,
                    SupplierId = 4,
                    ProductCode="32778",
                    Thumbnail="~/ProductImages/133205_body_0403.jpg"
                }, new Product
                {
                    Name = "LEGO 60084 – Đồ chơi xếp hình City Racing Bike Transporter",
                    Alias = "LEGO-do-choi-xep-hinh-City-Racing-Bike-Transporter",
                    ShortIntro = "Đồ chơi lắp ghép luôn là món đồ chơi giáo dục được nhiều bậc cha mẹ ưu tiên lựa chọn. Bé được tiếp xúc với món đồ chơi rèn luyện sự khéo léo, kiên nhẫn, sáng tạo ngay từ nhỏ sẽ giúp hình thành tư duy logic và sự phản xạ nhanh nhẹn",
                    Description ="Đồ chơi lắp ghép luôn là món đồ chơi giáo dục được nhiều bậc cha mẹ ưu tiên lựa chọn. Bé được tiếp xúc với món đồ chơi rèn luyện sự khéo léo, kiên nhẫn, sáng tạo ngay từ nhỏ sẽ giúp hình thành tư duy logic và sự phản xạ nhanh nhẹn. Hãy để bộ xếp hình LEGO 60084 đánh thức tiềm năng sáng tạo của bé. Bộ xếp hình LEGO 60084 với những mảnh ghép có màu sắc bắt mắt sẽ cho bé những giờ phút bay bổng cùng trí tưởng tượng, và rèn luyện sự khéo léo khi lắp các mảnh ghép. Sản phẩm sẽ là người bạn thân thiết cùng bé vừa học vừa chơi và làm nên những mô hình độc đáo." +
                        "Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra." +
                        "Bộ xếp hình giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, với nhiều chi tiết khác nhau, bé có thể xếp được nhiều mô hình khác nhau từ trí tưởng tượng phong phú của bé." +
                        "Các bộ phận đều được làm hoàn toàn bởi chất liệu nhựa cao cấp, tuyệt đối an toàn đến sức khỏe của bé. Mẹ sẽ an tâm cho bé thoải mái chơi đùa mà không lo sản phẩm gây nguy hại bé.",
                    Price = 419,
                    Actived = false,
                    Discount = 0.4f,
                    QtyPerUnit = "Cái",
                    Quantity = 54,
                    SupplierId = 4,
                    ProductCode="52742",
                    Thumbnail="~/ProductImages/lego-60084-o-choi-xep-hinh-city-racing001.jpg"
                }, new Product
                {
                    Name = "Combo 5 gói khăn ướt Nuna (30 tờ/gói) - Hương phấn Baby dịu nhẹ",
                    Alias = "Combo-5-goi-khan-uot-Nuna",
                    ShortIntro = "Combo 5 gói khăn ướt Nuna chiết xuất từ thành phần vải không dệt, dung dịch lô hội, chất giữ ẩm và có hương thơm tự nhiên, đem đến cảm giác thư giãn sảng khoái, chăm sóc làn da mềm mại của bạn và bé yêu. Chỉ 66.000đ cho trị giá 90.000đ.",
                    Description = "Combo 5 gói khăn ướt Nuna chiết xuất từ thành phần vải không dệt, mềm mại và không nhờn da, dung dịch lô hội, chất giữ ẩm, nước tinh khiết R.O giúp bảo vệ và giữ ẩm cho da luôn mịn màng." +
                        "Sản phẩm không chứa cồn, xà phòng, không gây kích ứng da, có mùi hương phấn Baby dịu nhẹ, đem lại cảm giác thoải mái và thư giãn cho người sử dụng." +
                        "Khăn ướt Nuna với chiết xuất lô hội làm ôn hòa, mát và giữ ẩm da, đảm bảo an toàn cho làn da nhạy cảm của em bé, thích hợp cho mọi gia đình." +
                        "Nắp mở tiện lợi, dễ dàng sử dụng, tiện dụng mang theo mọi lúc mọi nơi." + 
                        "Quy cách đóng gói: 30 tờ/gói. Kích thước: 200mm x 150mm/tờ",
                    Price = 66,
                    Actived = false,
                    Discount = 0.1f,
                    QtyPerUnit = "Cái",
                    Quantity = 11,
                    SupplierId = 2,
                    ProductCode="32758",
                    Thumbnail="~/ProductImages/khan_uot_Nuna001.jpg"
                }, new Product
                {
                    Name = "Bộ drap cotton nhung Senky loại 1 (1.8m x 2m)",
                    Alias = "Bo-drap-cotton-nhung-Senky-Loai1",
                    ShortIntro = "Bộ drap cotton nhung Senky loại 1 được may từ chất liệu cotton nhung cao cấp mềm mại, khả năng thấm hút mồ hôi tốt, ít xù lông giúp chăm sóc và nâng niu giấc ngủ của gia đình bạn. Chỉ 225.000đ cho trị giá 400.000đ.",
                    Description = "Bộ drap cotton nhung Senky loại 1 (1.8m x 2m) sẽ giúp chăm sóc, nâng niu giấc ngủ say và trọn vẹn của bạn cùng những người thân yêu." +
                        "Sản phẩm được may từ chất liệu cotton nhung cao cấp mềm mại, nhẹ nhàng mang lại cảm giác dễ chịu và êm ái cho người dùng." +
                        "Đường may đẹp, ít xù lông, thấm hút mồ hôi, đồng thời không bị phai màu hoặc nhòe họa tiết theo thời gian sử dụng." +
                        "Dễ dàng bảo quản, giặt ủi và mau khô luôn đảm bảo giấc ngủ của bạn và gia đình mỗi đêm." +
                        "Màu sắc tươi trẻ phối cùng hoa văn bắt mắt tô điểm cho không gian ngủ của bạn thêm lãng mạn, trẻ trung hơn.",
                    Price = 225,
                    Actived = false,
                    Discount = 0.0f,
                    QtyPerUnit = "Cái",
                    Quantity = 14,
                    SupplierId = 8,
                    ProductCode="12778",
                    Thumbnail="~/ProductImages/drap_cotton001.jpg"
                    
                }, new Product
                {
                    Name = "Quần Váy Chữ A Xinh Xắn",
                    Alias = "quan-vay-chu-a-xinh-xan-119321",
                    ShortIntro = "Quần Váy Chữ A Xinh Xắn – Cho Bạn Gái Vẻ Ngoài Nữ Tính Cùng Cảm Giác Tự Tin, Thoải Mái Khi Ra Phố. Giá 210.000 VNĐ, Còn 129.000 VNĐ, Giảm 39%. Chỉ Có Tại Hotdeal.vn!",
                    Description = "Quần giả váy thiết kế form chữ A, xếp ly xòe, thích hợp với các bạn gái chuộng phong cách thời trang nữ tính và ưa thích sự kín đáo, tinh tế." +
                        "Sản phẩm không chứa cồn, xà phòng, không gây kích ứng da, có mùi hương phấn Baby dịu nhẹ, đem lại cảm giác thoải mái và thư giãn cho người sử dụng." +
                        "Sản phẩm được may từ chất liệu tuyết mưa tạo form dáng đẹp cùng cảm giác dễ chịu khi mặc." +
                        " Dễ mix cùng các kiểu T-shirt, áo sơ mi, áo cách điệu khác nhau." +
                        "Đem đến cho bạn gái vẻ ngoài trẻ trung, thu hút khi dạo phố.Trọng lượng gói hàng cả bao bì: 300 gram",
                    Price = 210,
                    Actived = false,
                    Discount = 0.39f,
                    QtyPerUnit = "Cái",
                    Quantity = 10,
                    SupplierId = 8,
                    ProductCode = "52776",
                    Thumbnail = "~/ProductImages/quan-vay-chu-a-xinh-xan.jpg"
                }, new Product
                {
                    Name = "Gà Mổ Thóc Sáng Tạo – Vietoys",
                    Alias = "ga-mo-thoc-sang-tao-vietoys",
                    ShortIntro = "Gà Mổ Thóc Sáng Tạo–Vietoys – Có 5 Con Gà Gắn Với Hệ Thống Dây Và Quả Cầu Tạo Lực, Khi Lắc Tròn Mâm Gỗ, Đàn Gà Sẽ Mổ Thóc Và Tạo Âm Thanh Vui Tai – Mang Lại Cho Bé Tiếng Cười Sảng Khoái. Giá 159.000 VNĐ, Còn 109.000 VNĐ, Giảm 31%. Chỉ Có Tại Hotdeal.vn!",
                    Description = "Gà mổ thóc sáng tạo – Vietoys được thiết kế độc đáo gồm có 5 con gà gắn với hệ thống dây và quả cầu tạo lực, khi lắc tròn mâm gỗ, đàn gà sẽ mổ thóc và tạo âm thanh vui tai, mang lại cho bé yêu tiếng cười sảng khoái khi chơi." +
                        " Sản phẩm được làm bằng chất liệu gỗ cao cấp, sơn an toàn, các chi tiết được bo tròn tỉ mỉ đảm bảo không làm trầy xước da bé khi sử dụng." +
                        "Nhiều màu sắc bắt mắt được phối vui tươi, tạo sự thích thú cho bé khi chơi." +
                        "Đồ chơi mang tính giáo dục cao, kích thích tính sáng tạo, luyện tập sự ",
                    Price = 159,
                    Actived = false,
                    Discount = 0.31f,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode = "52776",
                    Thumbnail = "~/ProductImages/ga-mo-thoc-sang-tao-vietoys.jpg"
                }, new Product
                {
                    Name = "Áo Voan Phối Màu Dạo Phố",
                    Alias = "ao-voan-phoi-mau-dao-pho",
                    ShortIntro = "Áo Voan Phối Màu Dạo Phố - Kiểu Áo Form Rộng, Cổ Thuyền, Tay Dơi Thanh Thoát – Phối 3 Màu Trẻ Trung – Style Cá Tính Của Cô Nàng Hiện Đại. Giá 150.000 VNĐ, Còn 89.000 VNĐ, Giảm 41%. Chỉ Có Tại Hotdeal.vn!",
                    Description = " Áo voan phối màu dạo phố sở hữu form dáng rộng thanh thoát, áo cổ thuyền, tay dơi, dễ mặc." +
                        "Phối kiểu 3 màu nổi bật, bắt mắt sẽ góp phần tôn lên nét tươi trẻ của bạn gái." +
                        " Chất liệu áo là vải voan mềm mịn, thấm hút tối ưu sẽ tạo cho người mặc cảm giác thoải mái nhất." +
                        " Áo free size, form rộng dễ mặc. Bạn thoải mái kết hợp cùng short, jeans, kaki…" ,
                    Price = 150,
                    Actived = false,
                    Discount = 0.41f,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode = "52776",
                    Thumbnail = "~/ProductImages/ao-voan-phoi-mau-dao-pho.jpg"
                }, new Product
                {
                    Name = "Áo Thun Cánh Dơi Color Hè",
                    Alias = "ao-thun-canh-doi-color-xuan-he",
                    ShortIntro = "Áo Thun Cánh Dơi Color Hè – Áo Form Rộng, Phối Màu Sắc Tươi Trẻ - Tạo Phong Cách Trẻ Trung, Năng Động Cho Bạn Gái. Giá 129.000 VNĐ, Còn 75.000 VNĐ, Giảm 42%. Chỉ Có Tại Hotdeal.vn!",
                    Description = "Kiểu dáng áo form rộng, tay dơi tôn lên dáng vẻ thanh thoát, khỏe khoắn của bạn gái." +
                        "Là thiết kế giúp bạn gái che khuyết điểm tối ưu, kích cỡ free size còn mang đến cho người mặc cảm giác thoải mái." +
                        "Áo có kiểu phối màu sắc trẻ trung cho diện mạo bạn gái thêm nổi bật, hút mắt, sinh động trong những ngày hè nắng." +
                        "Chất liệu thun mềm mại, thấm hút tốt mồ hôi, vô cùng lý tưởng cho mùa hè." +
                        "Áo dễ kết hợp cùng nhiều kiểu jeans, short, kaki…",
                    Price = 129,
                    Actived = false,
                    Discount = 0.42f,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode = "52776",
                    Thumbnail = "~/ProductImages/ao-thun-canh-doi-color-xuan-he.jpg"
                }, new Product
                {
                    Name = "Áo Khoác Cách Điệu",
                    Alias = "ao-khoac-cach-dieu",
                    ShortIntro = "Áo Khoác Cách Điệu – Thiết Kế Form Rộng, Tà Thả Buông Cách Điệu Cá Tính – Cho Bạn Gái Thoải Mái Biến Hóa Phong Cách. Giá 185.000 VNĐ, Còn 125.000 VNĐ, Giảm 32%. Chỉ Có Tại Hotdeal.vn!",
                    Description = "Áo khoác cách điệu giúp bạn gái biến hóa nhiều phong cách, thể hiện gu thời trang trẻ trung, tươi mới." +
                        "Thiết kế áo form rộng, tay dài, tà cách điệu buông rủ tự do thể hiện nét phóng khoáng, cá tính của người mặc, đồng thời dễ biến tấu cùng trang phục." +
                        "Khăn ướt Nuna với chiết xuất lô hội làm ôn hòa, mát và giữ ẩm da, đảm bảo an toàn cho làn da nhạy cảm của em bé, thích hợp cho mọi gia đình." +
                        "Chất liệu thun cotton mịn co giãn và thấm hút mồ hôi tốt.Sản phẩm có nhiều màu sắc thời trang cho bạn lựa chọn phù hợp với sở thích." +
                        "Trọng lượng gói hàng cả bao bì: 100 gram",
                    Price = 125,
                    Actived = false,
                    Discount = 0.32f,
                    QtyPerUnit = "Cái",
                    Quantity = 3,
                    SupplierId = 1,
                    ProductCode = "52776",
                    Thumbnail = "~/ProductImages/ao-khoac-cach-dieu.jpg"
                });

            context.SaveChanges();
        }
    }
}