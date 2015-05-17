using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.DAL
{
    public class PicturesSeeder
    {
        public static void Seeder(ShopDbContext context)
        {
            context.Pictures.AddOrUpdate(
                 new Picture
                        {
                            Caption = "dam-body-lech-vai 001",
                            Path = "~/ProductImages/timthumb001.jpg",
                            Actived = true,
                            ProductId=12,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "dam-body-lech-vai 002",
                            Path = "~/ProductImages/timthumb002.jpg",
                            Actived = true,
                            ProductId=12,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "dam-body-lech-vai 003",
                            Path = "~/ProductImages/timthumb003.jpg",
                            Actived = true,
                            ProductId=12,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "dam-body-lech-vai004",
                            Path = "~/ProductImages/timthumb.jpg",
                            Actived = true,
                            ProductId=12,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Đầm Stella 001",
                            Path = "~/ProductImages/damStella001.jpg",
                            ProductId=13,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Đầm Stella 002",
                            Path = "~/ProductImages/damStella002.jpg",
                            ProductId=13,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Đầm Stella 003",
                            Path = "~/ProductImages/damStella003.jpg",
                            ProductId=13,
                            OrderNo = 0,
                        },
                         new Picture
                        {
                            Caption = "bo do dao pho Han Quoc 001",
                            Path = "~/ProductImages/bododaopho001.jpg",
                            Actived = true,
                            ProductId=14,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "bo do dao pho Han Quoc 002",
                            Path = "~/ProductImages/bododaopho002.jpg",
                            Actived = true,
                            OrderNo = 0,
                            ProductId=14,
                        },
                        new Picture
                        {
                            Caption = "bo do dao pho Han Quoc 003",
                            Path = "~/ProductImages/bododaopho003.jpg",
                            Actived = true,
                            ProductId=14,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao khoac nu hoodie 001",
                            Path = "~/ProductImages/aokhoacnuhoodie.jpg",
                            Actived = true,
                            ProductId=15,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao khoac nu hoodie 002",
                            Path = "~/ProductImages/aokhoacnuhoodie002.jpg",
                            Actived = true,
                            ProductId=15,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao khoac nu hoodie 003",
                            Path = "~/ProductImages/aokhoacnuhoodie003.jpg",
                            Actived = true,
                            ProductId=15,
                            OrderNo = 0,
                        },
                         new Picture
                        {
                            Caption = "ao thun nam 001",
                            Path = "~/ProductImages/aothunnamnu001.jpg",
                            Actived = true,
                            ProductId=16,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao thun nam 002",
                            Path = "~/ProductImages/aothunnamnu002.jpg",
                            Actived = true,
                            ProductId=16,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao thun nam 003",
                            Path = "~/ProductImages/aothunnamnu002.jpg",
                            Actived = true,
                            ProductId=16,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "bo do the thao 001",
                            Path = "~/ProductImages/bodothethao001.jpg",
                            Actived = true,
                            ProductId=17,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "bo do the thao 002",
                            Path = "~/ProductImages/bodothethao002.jpg",
                            Actived = true,
                            ProductId=17,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "bo do the thao 003",
                            Path = "~/ProductImages/bodothethao003.jpg",
                            Actived = true,
                            ProductId=17,
                            OrderNo = 0,
                        },
                          new Picture
                        {
                            Caption = "Bo-ta-quan-be-trai-2 goi 001",
                            Path = "~/ProductImages/bo-3-ta-quan-be-trai-2-goi-xl24.jpg",
                            Actived = true,
                            ProductId=18,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Combo-Bo-Do-Mac-Nha-Cho-Be 001",
                            Path = "~/ProductImages/133205_body_0201.jpg",
                            Actived = true,
                            ProductId=19,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Combo-Bo-Do-Mac-Nha-Cho-Be 002",
                            Path = "~/ProductImages/133205_body_0302.jpg",
                            Actived = true,
                            ProductId=19,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Combo-Bo-Do-Mac-Nha-Cho-Be 003",
                            Path = "~/ProductImages/133205_body_0403.jpg",
                            Actived = true,
                            ProductId=19,
                            OrderNo = 0,
                        },
                         new Picture
                        {
                            Caption = "LEGO-do-choi-xep-hinh-City-Racing-Bike-Transporter",
                            Path = "~/ProductImages/lego-60084-o-choi-xep-hinh-city-racing001.jpg",
                            Actived = true,
                            ProductId=20,
                            OrderNo = 0,
                        },
                         new Picture
                        {
                            Caption = "Combo-5-goi-khan-uot-Nuna 001",
                            Path = "~/ProductImages/khan_uot_Nuna001.jpg",
                            Actived = true,
                            ProductId=21,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Combo-5-goi-khan-uot-Nuna 002",
                            Path = "~/ProductImages/khan_uot_Nuna002.jpg",
                            Actived = true,
                            ProductId=21,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Combo-5-goi-khan-uot-Nuna 003",
                            Path = "~/ProductImages/khan_uot_Nuna003.jpg",
                            Actived = true,
                            ProductId=21,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Bộ drap cotton nhung Senky 001",
                            Path = "~/ProductImages/drap_cotton001.jpg",
                            Actived = true,
                            ProductId=22,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Bộ drap cotton nhung Senky 002",
                            Path = "~/ProductImages/drap_cotton002.jpg",
                            Actived = true,
                            ProductId=22,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Bộ drap cotton nhung Senky 003",
                            Path = "~/ProductImages/drap_cotton003.jpg",
                            Actived = true,
                            ProductId=22,
                            OrderNo = 0,
                        },
                         new Picture
                        {
                            Caption = "Khan uot Nuna 001",
                            Path = "~/ProductImages/khan_uot_Nuna001.jpg",
                            Actived = true,
                            ProductId=28,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "Khan uot Nuna 001",
                            Path = "~/ProductImages/khan_uot_Nuna002.jpg",
                            Actived = true,
                            ProductId=28,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "quan-vay-chu-a-xinh-xan 001",
                            Path = "~/ProductImages/quan-vay-chu-a-xinh-xan.jpg",
                            Actived = true,
                            ProductId=24,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "quan-vay-chu-a-xinh-xan 001",
                            Path = "~/ProductImages/quan-vay-chu-a-xinh-xan001.jpg",
                            Actived = true,
                            ProductId = 24,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "quan-vay-chu-a-xinh-xan 001",
                            Path = "~/ProductImages/quan-vay-chu-a-xinh-xan002.jpg",
                            Actived = true,
                            ProductId = 24,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "quan-vay-chu-a-xinh-xan 001",
                            Path = "~/ProductImages/quan-vay-chu-a-xinh-xan003.jpg",
                            Actived = true,
                            ProductId = 24,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ga-mo-thoc-sang-tao-vietoy",
                            Path = "~/ProductImages/ga-mo-thoc-sang-tao-vietoys.jpg",
                            Actived = true,
                            ProductId = 25,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ga-mo-thoc-sang-tao-vietoy",
                            Path = "~/ProductImages/ga-mo-thoc-sang-tao-vietoys001.jpg",
                            Actived = true,
                            ProductId = 25,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ga-mo-thoc-sang-tao-vietoy",
                            Path = "~/ProductImages/ga-mo-thoc-sang-tao-vietoys002.jpg",
                            Actived = true,
                            ProductId = 25,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ga-mo-thoc-sang-tao-vietoy",
                            Path = "~/ProductImages/ga-mo-thoc-sang-tao-vietoys003.jpg",
                            Actived = true,
                            ProductId = 25,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-voan-phoi-mau-dao-pho",
                            Path = "~/ProductImages/ao-voan-phoi-mau-dao-pho.jpg",
                            Actived = true,
                            ProductId = 26,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-voan-phoi-mau-dao-pho",
                            Path = "~/ProductImages/ao-voan-phoi-mau-dao-pho001.jpg",
                            Actived = true,
                            ProductId = 26,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-voan-phoi-mau-dao-pho",
                            Path = "~/ProductImages/ao-voan-phoi-mau-dao-pho002.jpg",
                            Actived = true,
                            ProductId = 26,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-voan-phoi-mau-dao-pho",
                            Path = "~/ProductImages/ao-voan-phoi-mau-dao-pho003.jpg",
                            Actived = true,
                            ProductId =26,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-thun-canh-doi-color-xuan-he",
                            Path = "~/ProductImages/ao-thun-canh-doi-color-xuan-he.jpg",
                            Actived = true,
                            ProductId = 27,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-thun-canh-doi-color-xuan-he",
                            Path = "~/ProductImages/ao-thun-canh-doi-color-xuan-he001.jpg",
                            Actived = true,
                            ProductId = 27,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-thun-canh-doi-color-xuan-he",
                            Path = "~/ProductImages/ao-thun-canh-doi-color-xuan-he002.jpg",
                            Actived = true,
                            ProductId = 27,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-thun-canh-doi-color-xuan-he",
                            Path = "~/ProductImages/ao-thun-canh-doi-color-xuan-he003.jpg",
                            Actived = true,
                            ProductId = 27,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-thun-canh-doi-color-xuan-he",
                            Path = "~/ProductImages/ao-thun-canh-doi-color-xuan-he004.jpg",
                            Actived = true,
                            ProductId = 27,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-khoac-cach-dieu",
                            Path = "~/ProductImages/ao-khoac-cach-dieu.jpg",
                            Actived = true,
                            ProductId = 28,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-khoac-cach-dieu",
                            Path = "~/ProductImages/ao-khoac-cach-dieu001.jpg",
                            Actived = true,
                            ProductId = 28,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-khoac-cach-dieu",
                            Path = "~/ProductImages/ao-khoac-cach-dieu002.jpg",
                            Actived = true,
                            ProductId = 28,
                            OrderNo = 0,
                        },
                        new Picture
                        {
                            Caption = "ao-khoac-cach-dieu",
                            Path = "~/ProductImages/ao-khoac-cach-dieu003.jpg",
                            Actived = true,
                            ProductId = 28,
                            OrderNo = 0,
                        }
                );
            context.SaveChanges();
        }
    }
}
