using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class SupplierSeeder
    {
        public static void Seed(ShopDbContext context)
        {
            var suppliers = new Supplier[]
            {
                new Supplier()
                {
                    Name = "Công ty CP đầu tư bầu trời",
                    ContactName = "Trần Đăng Nguyễn",
                    ContactTitle = "Quản lý bán hàng",
                    Description = "Intimex là cô ngty  kinh doanh xuất nhập khẩu dưới hình thức trao đổi hàng hóa" +
                                  "nội thương và hợp tác xã với các nước XHCN và một số nước khác.",
                    Address = "96 Trần Hưng Đạo - Hoàn Kiếm - Hà Nội",
                    Email = "info@intimexvietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://ww.intimexco.com",
                    Phone = "043-942-4250",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Oriental Vietnam",
                    ContactName = "Lê Linh Hương",
                    ContactTitle = "Quản lý đơn hàng",
                    Description = "Đặt cơ sở sản xuất tại Hà Nội, Oriental Việt Nam, công ty được Nhật Bản đầu tư 100%, hoạt động chủ yếu trong ngành may mặc. Cụ thể, Oriental Việt Nam đảm nhiệm việc sản xuất, gia công hàng dệt kim cao cấp. 100% sản phẩm là để xuất khẩu sang thị trường nước ngoài chẳng hạn như Nhật Bản… Công ty đề ra yêu cầu cao về chất lượng sản phẩm, vì thế, Oriental Việt Nam đặt ra nhiều nỗ lực để mang lại cho khách hàng sản phẩm tốt nhất cũng như đóng góp vào sự cải tiến xã hội.",
                    Address = "số 6, lô 11B Khu đô thị Trung Yên, Phố Trung Hòa, quận Cầu Giấy, HN ",
                    Email = "info@intimexvietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://ww.intimexco.com",
                    Phone = "043-321-4422",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Three Bambi Vietnam",
                    ContactName = "Nguyễn Hoàng Long",
                    ContactTitle = "Quản lý tiếp thị",
                    Description = "Thành lập năm 1995, Three Bambi Việt Nam là công ty với 100% vốn đầu tư từ Nhật Bản. Với hai nhà máy đặt tại Hồ Chí Minh, Three Bambi Việt Nam là nhà sản xuất, phân phối của những mặt hàng may mặc, có thể kể đến: đồ thể thao, áo khoác nam, quần áo trẻ em, quần áo mẫu giáo, và trang phục lót nam. Để xuất khẩu hàng hóa sang thị trường Nhật Bản, Three Bambi Việt Nam có hệ thống quản lí chặt chẽ từ khâu sản xuất đến giao nhận. Công ty sử dụng công nghệ hiện đại như phần mềm YUKA CAD, HASHIMA HN-770G. Khách hàng chính bao gồm Itochu, Chori, Kirinji… Three Bambi Việt Nam cũng được chứng nhận PUMA ",
                    Address = "Đường số 8, Khu Chế Xuất Tân Thuận, P. Tân Thuận Đông, Q. 7, Tp. Hồ Chí Minh ",
                    Email = "kuroda-t@thbv.com",
                    Fax = "043-942-3240",
                    HomePage = "http://thbv.com/?lang=vi",
                    Phone = "081-211-4455",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Công ty Thương Mại Tổng Hợp Sơn Anh",
                    ContactName = "Lê Văn Dũng",
                    ContactTitle = "Quản lý hóa đơn",
                    Description = "Công ty thương mại tổng hộp Sơn Anh chuyên phân phối các sản phẩm cao su silicone, các loại silicone, RTV, quartz, điện cực than chì và các loại hóa chất đặc biệt khác. Để phục vụ cho khách hàng tốt hơn, công ty cũng đã lắp đặt hệ thống kho hàng hiện đại tại Cảng Hà Nội, Đà Nẵng, Bình Dương và Thành phố Hồ Chí Minh.",
                    Address = "Số 06, 127/56 Văn Cao, Liễu Giai, Ba Đình, Hà Nội ",
                    Email = "sonanh@sonanh.com",
                    Fax = "043-942-3240",
                    HomePage = "http://www.sonanh.com/",
                    Phone = "043-332-4533",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Kondo Textile Vietnam",
                    ContactName = "Lê Minh Đức",
                    ContactTitle = "Quản lý kho",
                    Description = "Với cơ sở sản xuất đặt tại Bình Dương, công ty dệt Kondo Việt Nam là công ty con 100% dưới sự quản lí của công ty Kondo Nhật Bản. Hoạt động chuyên về ngành dệt may, sản phẩm công ty dệt Kondo Việt Nam là các loại sợi. Sở hữu đội ngũ nhân viên lành nghề cùng dây chuyền sản xuất hiện đại chuyển giao từ Nhật Bản, công ty cam kết sản xuất các loại sản phẩm tốt đạt tiêu chuẩn quốc tế. Nhờ vào sự ưu tiên vào chất lượng, công ty có thể xuất khẩu sản phẩm sang thị trường nước ngoài như Trung Quốc, Nhật Bản",
                    Address = "Khu Công Nghiệp Mỹ Phước, Đường N6,H. Bến Cát,Bình Dương ",
                    Email = "info@intimexvietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://ww.intimexco.com",
                    Phone = "982-942-4422",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Midori Apparel Vietnam",
                    ContactName = "Hoàng Nhật Anh",
                    ContactTitle = "Quản lý bán hàng",
                    Description = "Midori Anzen là một trong những công ty hằng đầu tại Nhật Bản hoạt động trong lĩnh vực liên quan đến chăm sóc, bảo vệ và cải thiện sức khỏe người dân. Nhà máy và văn phòng kinh doanh của Midori Anzen đã có mặt trên toàn quốc. Theo đuổi châm ngôn hoạt động của công ty mẹ, “nỗ lực cho sự an toàn ngày hôm nay và ngày mai”, công ty Midori Apparel Việt Nam (MAV) được thành lập năm 2004. MAV chú trọng sản xuất đồng phục bảo hộ lao động và quần áo trắng dùng trong y tế, chế biến hải sản và công nghệ cao. Với máy móc hiện đại, đội ngũ nhân viên tay nghề cao, MAV cam kết sản xuất những sản phẩm đạt tiêu chuẩn vệ sinh quốc tế. MAV đang xây dựng nhà máy thứ hai dự kiến đi vào hoạt động sớm và tăng năng suất cho công ty.",
                    Address = "Lô số 10, khu công nghiệp Khai Quang, Vĩnh Yên, Vĩnh Phúc ",
                    Email = "info@midorivietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://midoriapparel.vn/",
                    Phone = "3211-942-4250",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Takubo 3",
                    ContactName = "Nguyễn Minh Anh",
                    ContactTitle = "Quản lý tiếp thị",
                    Description = "Với cơ sở sản xuất đặt tại Bình Dương, công ty dệt Kondo Việt Nam là công ty con 100% dưới sự quản lí của công ty Kondo Nhật Bản. Hoạt động chuyên về ngành dệt may, sản phẩm công ty dệt Kondo Việt Nam là các loại sợi. Sở hữu đội ngũ nhân viên lành nghề cùng dây chuyền sản xuất hiện đại chuyển giao từ Nhật Bản, công ty cam kết sản xuất các loại sản phẩm tốt đạt tiêu chuẩn quốc tế. Nhờ vào sự ưu tiên vào chất lượng, công ty có thể xuất khẩu sản phẩm sang thị trường nước ngoài như Trung Quốc, Nhật Bản",
                    Address = "Khu Công Nghiệp Mỹ Phước, Đường N6,H. Bến Cát,Bình Dương ",
                    Email = "info@intimexvietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://ww.intimexco.com",
                    Phone = "043-942-4250",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Công ty TNHH Takubo Việt Nam",
                    ContactName = "Lê Minh Tân",
                    ContactTitle = "Quản lý bán hàng",
                    Description = "Với trụ sở đặt tại Nhật Bản, công ty Takubo bắt đầu hoạt động năm 1934. Nhắm đến việc đóng góp vào sự phát triển của ngành may mặc, công ty chuyên về kinh doanh các nguyên liệu, phụ kiện ngành may mặc. Cụ thể, dòng sản phẩm Takubo mang đến có thể kể đến chỉ may công nghiệp, vải lót, vải lót trong, đăng ten, dây kéo, máy may, vải may mặc… Là nhà sản xuất hằng đầu các loại vật liệu may mặc, Takubo đã nhận được chứng chỉ ISO 9001 và trở thành đối tác đáng tin cậy của nhiều các doanh nghiệp may như Itochu, Gunze và Moririn… Năm 2011, công ty Takubo Việt Nam, công ty con Việt Nam của Takubo, được thành lập với cơ sở ở Hà Nội. Công ty chuyên kinh doanh, xuất/ nhập khẩu các loại chỉ may, các vật liệu may mặc khác. Dựa trên bề dày kinh nghiệm đồng thời bí quyết đặc biệt, Takubo Việt Nam có thể mang đến cho khách hàng sản phẩm mong muốn trong tác phong làm việc chuyên nghiệp.",
                    Address = "No 3 Alley No 91/16-Lane 91 Tran Duy Hung street, Trung hoa ward, Cau giay district, Ha noi city, Viet Nam ",
                    Email = "seike.toshio@takubo-grp.com",
                    Fax = "043-942-3240",
                    HomePage = "http://www.takubo-grp.co.jp/en/",
                    Phone = "321-941-4422",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Quadrille & Vera International",
                    ContactName = "Nguyễn Hoàng Long",
                    ContactTitle = "Quản lý đơn hàng",
                    Description = "Với cơ sở sản xuất đặt tại Bình Dương, công ty dệt Kondo Việt Nam là công ty con 100% dưới sự quản lí của công ty Kondo Nhật Bản. Hoạt động chuyên về ngành dệt may, sản phẩm công ty dệt Kondo Việt Nam là các loại sợi. Sở hữu đội ngũ nhân viên lành nghề cùng dây chuyền sản xuất hiện đại chuyển giao từ Nhật Bản, công ty cam kết sản xuất các loại sản phẩm tốt đạt tiêu chuẩn quốc tế. Nhờ vào sự ưu tiên vào chất lượng, công ty có thể xuất khẩu sản phẩm sang thị trường nước ngoài như Trung Quốc, Nhật Bản",
                    Address = "30, đường 11F, Thảo Điền, Q2, HCM ",
                    Email = "info@intimexvietnam.com",
                    Fax = "043-942-3240",
                    HomePage = "http://www.vera.com.vn/",
                    Phone = "043-942-4250",
                    Actived = true
                },
                new Supplier()
                {
                    Name = "Showa Gloves Vietnamt",
                    ContactName = "Trần Huy Nhật",
                    ContactTitle = "Quản lý tiếp thị",
                    Description = "Showa bắt nguồn là một công ty Nhật Bản chuyên về sản phẩm bảo vệ tay. Sau nhiều năm hoạt động, Showa đã chiếm được một vị trí nhất định trong thị trường nội địa lẫn quốc tế. Là một chi nhánh của công ty số 1 về sản xuất gang tay, Showa Việt Nam cũng tham gia sản xuất găng tay dùng lao động và hộ gia đình. Nhấn mạnh về độ bền, chất lượng và sáng tạo, Showa Việt Nam đặt nỗ lực vào từng sản phẩm. Vì thế, để sản xuất sản phẩm đạt đến mong đợi của khách hàng, Showa Việt Nam trang bị cơ sở vật chất với công nghệ Nhật Bản, hệ thống quản lí chất lượng, môi trường chặt chẽ. Năm 2009, Showa Việt Nam đã được chứng ",
                    Address = "23 Tu Do Avenue , Vsip, Thuan An District,.Binh Duong Province. ",
                    Email = "manh@thuyhungphat.com",
                    Fax = "043-942-3240",
                    HomePage = "http://www.showa-gloves.com.vn/en/home",
                    Phone = "063-530-9933",
                    Actived = true
                }
            };  

            context.Suppliers.AddOrUpdate(s => s.Name, suppliers);

            context.SaveChanges();
        }
    }
}