using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class ShipperSeeder
    {
        public static void Seed(ShopDbContext context)
        {
            context.Shippers.AddOrUpdate(s => s.CompanyName,
                new Shipper()
                {
                    CompanyName = "Công ty cổ phần vận tải & dịch vụ Phúc Tâm",
                    Address = "23rd Floor, AB Tower, 76 Le Lai Street, Ho Chi Minh City ",
                    Phone = "083-993-9922"
                }, new Shipper()
                {
                    CompanyName = "Công ty TNHH SX - TM  - DV Long Phan",
                    Address = "Lầu 4 Toà nhà DHouse 39 Nguyễn Thị Diệu Phường 6 Quận 3 ",
                    Phone = "023-443-4422"
                },
                new Shipper()
                {
                    CompanyName = "Công ty giải pháp hàng hóa Phương Nam",
                    Address =
                        "Suite B601 The Manor, 91 Nguyen Huu Canh Street, Ward22, Binh Thanh District, Ho Chi Minh, Vietnam",
                    Phone = "1122-993-4467"
                },
                new Shipper()
                {
                    CompanyName = "Công Ty TNHH Ấn Lĩnh",
                    Address =
                        "1/59 An Dương Vương, Tp. Huế, Thừa Thiên-Huế",
                    Phone = "1122-993-4467"
                },
                new Shipper()
                {
                    CompanyName = "Công Ty TNHH Camera Long Phát",
                    Address =
                        "Số 113/20A, Đường Tân Chánh Hiệp 05, P. Tân Chánh Hiệp, Q. 12, Tp. Hồ Chí Minh (TPHCM)",
                    Phone = "1122-993-4467"
                },
                new Shipper()
                {
                    CompanyName = "Cửa Hàng Máy Ảnh Ngọc Camera",
                    Address =
                        "112 Trần Hưng Đạo, P.Phạm Ngũ Lão, Q.1, Tp. Hồ Chí Minh (TPHCM)",
                    Phone = "083-931-9571"
                },
                new Shipper()
                {
                    CompanyName = "Le Chef - Quán Tây Bình Dân",
                    Address =
                        "413/21 Lê Văn Sỹ, P. 12, Q. 3, Tp. Hồ Chí Minh (TPHCM)",
                    Phone = "1122-993-4467"
                },
                new Shipper()
                {
                    CompanyName = "Công Ty TNHH Thiết Bị Âm Thanh - Ánh Sáng Trường Thịnh",
                    Address =
                        "580 Điện Biên Phủ, P. 11, Q. 10, Tp. Hồ Chí Minh (TPHCM)",
                    Phone = "083-830-3571"
                },
                new Shipper()
                {
                    CompanyName = "Công Ty TNHH Thương Mại Dịch Vụ Sản Xuất Tân Lộc Tấn",
                    Address =
                        "329 Thoại Ngọc Hầu, P. Hiệp Tân, Q. Tân Phú, Tp. Hồ Chí Minh (TPHCM)",
                    Phone = "086-267-9619"
                },
                new Shipper()
                {
                    CompanyName = "Công ty TNHH Thành Bưởi",
                    Address = "72 Lê Thánh Tôn, Phường Bến Nghé, Quận 1  ",
                    Phone = "3311-221-4422"
                });

            context.SaveChanges();
        }
    }
}