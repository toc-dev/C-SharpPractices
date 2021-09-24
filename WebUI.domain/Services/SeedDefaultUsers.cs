using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Services
{
    public static class SeedDefaultUsers
    {
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
            Birthday = new DateTime(10 / 23 / 1998),
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

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            if ((await context.Database.GetPendingMigrationsAsync()).Any()) await context.Database.MigrateAsync();

            var userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<User>>();

            CreateSuperAdmin(userManager, Onah);
            CreateAdmin(userManager, Kachi);
            CreateAdmin(userManager, Tochi);
            CreateCustomers(userManager, Alex);
            CreateCustomers(userManager, Chikki);
            CreateCustomers(userManager, Dara);
        }

        static async void CreateSuperAdmin(UserManager<User> userManager, User Defaultuser)
        {
            var user = await userManager.FindByEmailAsync(Defaultuser.Email);
            if (user != null) return;
            user = Defaultuser;   
            
            var createUser = await userManager.CreateAsync(user, "4KatochiBank$");

            if (createUser.Succeeded) await userManager.AddToRoleAsync(user, Roles.GrandMaster.ToString());
        }

        static async void CreateAdmin (UserManager<User> userManager, User Defaultuser)
        {
            var user = await userManager.FindByEmailAsync(Defaultuser.Email);
            if (user != null) return;
            user = Defaultuser;

            var createUser = await userManager.CreateAsync(user, "4KatochiBank$");

            if (createUser.Succeeded) await userManager.AddToRoleAsync(user, Roles.Masters.ToString());
        }

        static async void CreateCustomers (UserManager<User> userManager, User Defaultuser)
        {
            var user = await userManager.FindByEmailAsync(Defaultuser.Email);
            if (user != null) return;
            user = Defaultuser;

            var createUser = await userManager.CreateAsync(user, "4KatochiBank$");

            if (createUser.Succeeded) await userManager.AddToRoleAsync(user, Roles.Customers.ToString());
        }
    }

}
