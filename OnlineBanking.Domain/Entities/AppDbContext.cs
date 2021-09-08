﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OnlineBanking.Domain.Entities
{
   public class AppDbContext : DbContext
    {      

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }        

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }      
    }
}
