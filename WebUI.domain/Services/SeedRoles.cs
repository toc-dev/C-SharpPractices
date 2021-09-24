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
    public static class SeedRoles
    {
        static AppRole GrandMaster = new AppRole { Name = Roles.GrandMaster.ToString() };
        static AppRole Masters = new AppRole { Name = Roles.Masters.ToString() };
        static AppRole Customers = new AppRole { Name = Roles.Customers.ToString() };
        private static RoleManager<AppRole> _roleManager;

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            if ((await context.Database.GetPendingMigrationsAsync()).Any()) await context.Database.MigrateAsync();

            _roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();

            await Create(GrandMaster);
            await Create(Masters);
            await Create(Customers);
        }

        private static async Task Create(AppRole role)
        {
            if (!await _roleManager.RoleExistsAsync(role.Name))
            {
                await _roleManager.CreateAsync(role);
            }
        }
    }

}
