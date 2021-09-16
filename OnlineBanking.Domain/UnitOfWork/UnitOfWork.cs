using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private IRepository<Customer> _customers;
        private IRepository<Account> _accounts;
        //public IRepository<Customer> Customers { get { return _customers ??= _customers = new CustomerRepository(_context); } }
        //public IRepository<Account> Accounts { get { return _accounts ??= _accounts = new AccountRepository(_context); } }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
