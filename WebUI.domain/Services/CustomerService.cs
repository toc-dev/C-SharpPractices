using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebUI.Domain.Model;

namespace WebUI.Domain.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Get(int Id)
        {
            Customer customer = null;
            try
            {
                customer = _unitOfWork.Customers.Get(Id);
            }
            catch
            {
                return customer;
            }
            return customer;
        }

        public Customer CreateCustomer(CreateCustomerViewModel model)
        {
            var customer = new Customer
            {
                FirstName = $"{model.FirstName}",
                LastName = $"{model.LastName}",
                Gender = model.Gender,
                Birthday = model.Birthday,
                Age = DateTime.Now.Year - model.Birthday.Year,
                Country = $"{model.Country}",
                Account = new Account
                {
                    //AccountNumber = $"{RandomNumberGenerator.GetInt32(999999999)}",
                    CreatedAt = DateTime.Now,
                    CreatedBy = $"{model.CreatedBy}",
                    Balance = model.Balance,
                    AccountType = model.AccountType
                },
                CreatedAt = DateTime.Now,
                CreatedBy = $"{model.CreatedBy}"
            };
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();

            return customer;
        }

        public Account Account { get; set; }
        public int Update(UpdateViewModel model, int Id)
        {
            int updatedRow = 0;
            var customer = _unitOfWork.Customers.Get(Id);
            customer.FirstName = model.FirstName ??= customer.FirstName;
            customer.LastName = model.LastName ??= customer.LastName;
            updatedRow = _unitOfWork.Commit();
            return updatedRow;
        }
    }
}
