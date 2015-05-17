using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class CategorySeeder
    {
        public static void Seed(ShopDbContext context)
        {
            var topCates = new Category[]
            {
                new Category()
                {
                    Name = "Thời trang nữ",
                    Alias = "thoi-trang-nu",
                    Description = "Đồ thể thao, áo, quần, áo khoác nử",
                    IconPath = "~/Images/thoitrangnu.jpg",
                    Actived = true,
                    OrderNo = 2,
                    ParentId = null
                },
                new Category()
                {
                    Name = "Thời trang nam",
                    Alias = "thoi-trang-nam",
                    Description = "Đồ thể thao, áo, quần, áo khoác nam",
                    IconPath = "~/Images/thoitrangnam.jpg",
                    Actived = true,
                    OrderNo = 2,
                    ParentId = null
                },
                new Category()
                {
                    Name = "Phụ kiện",
                    Alias = "phu-kien",
                    Description = "Đồng hồ, ba lô, túi xách, giày dép, trang sức",
                    IconPath = "~/Images/phukien.jpg",
                    Actived = true,
                    OrderNo = 3,
                    ParentId = null
                },
                new Category()
                {
                    Name = "Mẹ và bé",
                    Alias = "me-va-be",
                    Description = "Set đồ dành cho bà bầu, mẹ và trẻ nhỏ",
                    IconPath = "~/Images/mevabe.jpg",
                    Actived = true,
                    OrderNo = 4,
                    ParentId = null
                }
            };
            context.Categories.AddOrUpdate(c=>c.Alias,topCates);
            context.SaveChanges();

            var ttNuId = topCates.Single(x => x.Alias == "thoi-trang-nu").CategoryId;
            var ttNuSubCates = new Category[]
            {
                new Category
                {
                    Name = "Đầm - Váy",
                    Alias = "dam-vay",
                    Description = "Váy, đầm dạ tiệc, đầm dạo phố, đầm công sở",
                    IconPath = null,
                    Actived = true,
                    OrderNo = 1,
                    ParentId = ttNuId
                },
                new Category
                {
                    Name = "Áo nữ",
                    Alias = "ao-nu",
                    Description = "Áo thun, áo sơ-mi, áo khoác nữ",
                    IconPath = null,
                    Actived = true,
                    OrderNo = 2,
                    ParentId = ttNuId
                }
            };
            context.Categories.AddOrUpdate(c=>c.Alias,ttNuSubCates);

            var ttNamId = topCates.Single(x => x.Alias == "thoi-trang-nam").CategoryId;
            var ttNamSubCates = new Category[]
            {
                new Category
                {
                    Name = "Áo nam",
                    Alias = "ao-nam",
                    Description = "Áo thun, áo sơ-mi, áo khoác nam",
                    IconPath = null,
                    Actived = true,
                    OrderNo = 1,
                    ParentId = ttNamId
                },
                new Category
                {
                    Name = "Đồ thể thao nao",
                    Alias = "do-the-thao-nam",
                    Description = "Bộ đồ thể thao, phụ kiện dành cho nam",
                    IconPath = null,
                    Actived = true,
                    OrderNo = 2,
                    ParentId = ttNamId
                }
            };
            context.Categories.AddOrUpdate(c=>c.Alias,ttNamSubCates);

            context.SaveChanges();
        }
    }
}