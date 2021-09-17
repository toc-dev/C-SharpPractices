using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {

        }

        
    }
}
