using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<Account> Accounts { get; }
        //IRepository<Customer> Customers { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
