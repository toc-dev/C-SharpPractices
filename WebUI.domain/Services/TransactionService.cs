using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Interfaces.Services;
using WebUI.domain.Models;
using WebUI.Domain.Interfaces.Services;

namespace WebUI.domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        public TransactionService(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository, IAccountService accountService, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _accountService = accountService;
            _customerService = customerService;
        }
        public (bool success, string message) Deposit(DepositViewModel model)
        {
            var account = _accountService.Get(model.Customer.Account.Id);
            var isValidAccount = account != null;
            var isActiveAccount = account?.IsActive;

            if (!isValidAccount || !isActiveAccount.Value)
            {
                var message = !isActiveAccount.Value ? "Account is inactive. Please reactivate" : "Your account is in invalid, please create an account";
                return (false, message);
            }
            account.Balance += model.Amount;
            var transaction = new Transaction
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Credit,
                UserId = model.Customer.UserId
            };
            _transactionRepository.Add(transaction);
            var affectedRows = _unitOfWork.Commit();
            return affectedRows > 0 ? (true, "Deposit successful!") : (false, "An error occured! Try again");

        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public (bool success, string message) Transfer(TransferViewModel model)
        {
            var senderAccount = _accountService.Get(model.Customer.Account.Id);
            var recipient
        }

        public (bool success, string message) Withdrawal(WithdrawalViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
