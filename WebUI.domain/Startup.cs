using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.UnitOfWork;
using WebUI.Domain.Interfaces.Repositories;
using OnlineBanking.Domain.Repositories;
using WebUI.Domain.Interfaces.Services;
using WebUI.Domain.Services;
using Microsoft.AspNetCore.Identity;
using WebUI.Domain.Interfaces;

namespace WebUI.domain
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OBConnection")));

            services.AddControllersWithViews();

            services.AddScoped<DbContext, ApplicationDbContext>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<ICustomerService, CustomerService>();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                //Other options go here
            }).AddEntityFrameworkStores<ApplicationDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });

        }
    }
}
