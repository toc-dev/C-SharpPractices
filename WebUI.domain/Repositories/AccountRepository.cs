using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using WebUI.domain.Model;

namespace WebUI.Domain.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context ):base(context)
        {
            
        }

        public static void Add(RegisterViewModel registerUser)
        {
            throw new NotImplementedException();
        }
    }
}
