using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Models;

namespace WebUI.domain.Interfaces.Services
{
    public interface ICustomerService
    {
        int? Add(Customer customer);
        public (bool isAboveMinAge, int AffectedRows) Add(RegisterUserViewModel registerUser);
        public Customer GetCustomer(string userId);
        public Customer GetCustomerAccount(string accountId);
    }
}
