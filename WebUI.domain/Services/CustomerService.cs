using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.HelperClasses;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebUI.domain.Interfaces.Services;
using WebUI.domain.Models;
using WebUI.domain.Utilities;

namespace WebUI.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;

        }

        public int? Add(Customer customer)
        {
            _customerRepository.Add(customer);
            int? result = _unitOfWork.Commit();
            return result;

        }

        public (bool isAboveMinAge, int AffectedRows) Add(RegisterUserViewModel registerUser)
        {
            int AffectedRows = default;
            var isAgeValid = ValidateAge.IsAgeValid(registerUser.Birthday.Value);
            var customer = new Customer
            {
                UserId = registerUser.Id,
                Birthday = registerUser.Birthday.Value,
                Gender = registerUser.Gender,
                Account = new Account
                {
                    AccountType = registerUser.AccountType,
                    AccountNumber = Convert.ToInt32(AccountNumberGenerator.RandomAccountNumber(10000000, 99999999)),
                    CreatedBy = registerUser.CreatedBy,
                    CreatedAt = DateTime.Now,
                    Balance = registerUser.AccountType != AccountType.Student ? 0 : 5000,
                    IsActive = true

                },
            };
            _customerRepository.Add(customer);
            AffectedRows = _unitOfWork.Commit();
            return (isAgeValid, AffectedRows);
        }

        public Customer GetCustomer(string userId)
        {
            return _customerRepository.Find(a => a.Id == userId).FirstOrDefault();
        }

        public Customer GetCustomerAccount(string accountId)
        {
            return _customerRepository.Find(a => a.Account.Id.ToString() == accountId).FirstOrDefault();
        }
    }
}
