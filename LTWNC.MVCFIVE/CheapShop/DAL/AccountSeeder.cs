using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheapShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CheapShop.DAL
{
    public class AccountSeeder
    {
        public static void Seed(ShopDbContext context)
        {
            var userManager = new UserManager<Account>(new UserStore<Account>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string adminRole = "Admin",
                managerRole = "Manager",
                saleRole = "Salesman",
                customerRole = "Customer",
                userName = "longtran",
                password = "123456",
                email = "longtnctk35@gmail.com";

            //tạo các quyền, vai trò của người dùng trong hệ thống
            if (!roleManager.RoleExists(adminRole))
                roleManager.Create(new IdentityRole(adminRole));
            if (!roleManager.RoleExists(managerRole))
                roleManager.Create(new IdentityRole(managerRole));
            if (!roleManager.RoleExists(saleRole))
                roleManager.Create(new IdentityRole(saleRole));
            if (!roleManager.RoleExists(customerRole))
                roleManager.Create(new IdentityRole(customerRole));
        
            //tao tai khoan admin
            var adminUser = new Account()
            {
                UserName = userName,
                Email = email,
                PhoneNumber = "09822223344",
                Profile = new UserProfile()
                {
                    FirstName = "Trần Như",
                    LastName = "Long",
                    Address = "8/32 Vo Truong Toan",
                    BirthDate = new DateTime(1992, 8, 31),
                    JobPosition = "Lập trình Java",
                    Picture = "~/Images/a1.jpg"
                }
            };

            var result = userManager.Create(adminUser, password);

            //Gan quyen admin va user cho nguoi dung vua tao
            if (result.Succeeded)
            {
                userManager.AddToRole(adminUser.Id, adminRole);
                userManager.AddToRole(adminUser.Id, managerRole);
            }

            //tao mot tai khoan khach hang
            var customer = new Account()
            {
                UserName = "phongnvt",
                Email = "phongnvt@gmail.com",
                PhoneNumber = "0899922243",
                Profile = new UserProfile()
                {
                    FirstName = "Nguyen Van Phong",
                    LastName = "Tran",
                    Address = "43A Bui Thi Xua, Phuong 8, Da Lat",
                    BirthDate = new DateTime(1990, 2, 4),
                }
            };

            result = userManager.Create(customer, password);

            //gan quyen cho tai khoan khach hang
            if (result.Succeeded)
            {
                userManager.AddToRole(customer.Id, customerRole);
            }
        }
    }
}