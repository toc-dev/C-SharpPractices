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
        static User Onah = new User
        {
            Email = "theGrandestMaster@bezao.com",
            PhoneNumber = "08034735341",
            UserName = "Onah",
            Address = new Address
            {
                PlotNo = 32,
                StreetName = "Bezao street",
                City = "Tenece City",
                State = "Enugu",
                Country = "Nigeria",
            },
            Birthday = new DateTime(09 / 22 / 1907),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Gender = Gender.Male

        };
        static User Kachi = new User
        {
            Email = "kachi@bezao.com",
            PhoneNumber = "08034735340",
            UserName = "Kachii",
            Address = new Address
            {
                PlotNo = 32,
                StreetName = "Bezao street",
                City = "Tenece City",
                State = "Enugu",
                Country = "Nigeria",
            },
            Birthday = new DateTime(10 / 23 / 1900),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Gender = Gender.Male
        };
        static User Tochi = new User
        {
            Email = "tochi@bezao.com",
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
            Birthday = new DateTime(09 / 30 / 1904),
            CreatedAt = DateTime.Now,
            CreatedBy = "Developer",
            Gender = Gender.Male
        };

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

            await CreateUser(userManager, Onah, Roles.GrandMaster.ToString());
            await CreateUser(userManager, Tochi, Roles.Masters.ToString());
            await CreateUser(userManager, Alex, Roles.Customers.ToString());
            await CreateUser(userManager, Chikki, Roles.Customers.ToString());
            await CreateUser(userManager, Dara, Roles.Customers.ToString());
            await CreateUser(userManager, Kachi, Roles.Masters.ToString());


            static async Task CreateUser(UserManager<User> userManager, User defaultUser, string roleName)
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user != null) return;
                user = defaultUser;

                var createUser = await userManager.CreateAsync(user, "4KatochiBank$");

                if (createUser.Succeeded) await userManager.AddToRoleAsync(user, roleName);
            }


        }

    }
}
