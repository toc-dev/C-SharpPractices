using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using OnlineBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
