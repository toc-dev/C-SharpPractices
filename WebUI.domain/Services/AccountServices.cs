using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Models;
using WebUI.Domain.Interfaces.Services;

namespace WebUI.domain.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public void checkBalance(User user)
        {
            throw new NotImplementedException();
        }

        public Account Get(string accountNumber)
        {
            return _accountRepository.Find(a => a.AccountNumber.ToString() == accountNumber).FirstOrDefault();
            //return _accountRepository.Get()
        }

        public Account Get(Customer customer)
        {
            return customer.Account;
        }

        public Account Get(Guid Id)
        {
            return _accountRepository.Find(a => a.Id==Id.ToString()).FirstOrDefault();

        }

        public int Update(UpdateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
