using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnlineBanking.Domain.Entities
{
   public class ApplicationDbContext : IdentityDbContext<User>
    {       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }        

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        
    }
}
