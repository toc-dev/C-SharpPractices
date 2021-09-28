using System;
using System.Collections.Generic;
using System.Text;
using WebUI.domain.Models;
using OnlineBanking.Domain.Entities;

namespace WebUI.domain.Interfaces.Services
{
    public interface ITransactionService
    {
        public (bool success, string message) Withdrawal(WithdrawalViewModel model);
        public (bool success, string message) Deposit(DepositViewModel model);
        public (bool success, string message) Transfer(TransferViewModel model);
        public IEnumerable<Transaction> GetAll();
    }
}
