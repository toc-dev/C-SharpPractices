using OnlineBanking.Domain.Entities;
using WebUI.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Customer> Customers { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
