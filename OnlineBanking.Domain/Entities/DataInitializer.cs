using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Domain.Entities
{
    public static class DataInitializer
    {
        static AppRole GrandMaster = new AppRole { Name = Roles.GrandMaster.ToString() };
        static AppRole Masters = new AppRole { Name = Roles.Masters.ToString() };
        static AppRole Customers = new AppRole { Name = Roles.Customers.ToString() };

        static User Onah = new User { Email = "theGrandestMaster@bezao.com" };
        static User Kachi = new User { Email = "kachi@bezao.com" };
        static User Tochi = new User { Email = "tochi@bezao.com" };
        static User Alex = new User
        {
            FullName = "Ogubuike Alex",
            PhoneNumber = "08034735342",
            UserName = "GirlCode",
            Address = new Address
            {
                PlotNo = 32,
                StreetName = "Bezao street",
                City = "Tenece City",
                State = "Enugu",
                Country = "Nigeria",
            },
            Birthday = new DateTime(10/23/1998),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Email = "alex@bezao.com",
            Gender = Gender.PreferNotToSay      
        };
        static User Chikki = new User
        {
            FullName = "Chinese Chikki",
            PhoneNumber = "08034735343",
            UserName = "Chinelsy",
            Address = new Address
            {
                PlotNo = 32,
                StreetName = "Bezao street",
                City = "Tenece City",
                State = "Enugu",
                Country = "Nigeria",
            },
            Birthday = new DateTime(10 / 24 / 1999),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Email = "chikki@bezao.com",
            Gender = Gender.Female
        };
        static User Dara = new User
        {
            FullName = "Dara Johnson",
            PhoneNumber = "08034735344",
            UserName = "Dadara",
            Address = new Address
            {
                PlotNo = 2,
                StreetName = "Genesys street",
                City = "Tenece City",
                State = "Enugu",
                Country = "Nigeria",
            },
            Birthday = new DateTime(10 / 2 / 1988),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Email = "dara@bezao.com",
            Gender = Gender.Female
        };
        public static async Task SeedRolesAsync( RoleManager<AppRole> roleManager)
        {
            await roleManager.CreateAsync(GrandMaster);
            await roleManager.CreateAsync(Masters);
            await roleManager.CreateAsync(Customers);
        }
        
        public static async Task DefaultUsers(UserManager<User> userManager)
        {
            await userManager.CreateAsync(Onah, "4KatochiBank$");
            await userManager.AddToRoleAsync(Onah, Roles.GrandMaster.ToString());

            await userManager.CreateAsync(Kachi, "4KatochiBank$");
            await userManager.AddToRoleAsync(Kachi, Roles.GrandMaster.ToString());

            await userManager.CreateAsync(Tochi, "4KatochiBank$");
            await userManager.AddToRoleAsync(Tochi, Roles.GrandMaster.ToString());

            await userManager.CreateAsync(Alex, "4KatochiBank$");
            await userManager.AddToRoleAsync(Alex, Roles.Customers.ToString());

            await userManager.CreateAsync(Chikki, "4KatochiBank$");
            await userManager.AddToRoleAsync(Chikki, Roles.Customers.ToString());

            await userManager.CreateAsync(Dara, "4KatochiBank$");
            await userManager.AddToRoleAsync(Dara, Roles.Customers.ToString());                
            
        }

    }

}
