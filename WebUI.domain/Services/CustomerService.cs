using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebUI.domain.Utilities;

namespace WebUI.Domain.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       /* public int CreateCustomer(RegisterCustomerViewModel model, bool IsUserExist)
        {
            var customer = new Customer
            {
                //FirstName = model.FirstName,
                //LastName = model.LastName,
                //Age = model.Age,
                //Nationality = model.Country,
                //CreatedAt = DateTime.Now,
                //CreatedBy = "Admin Name",
                //Account = new Account
                //{
                //    AccountNumber = int.Parse(Tools.GenerateAccountNumber()),
                //    AccountType = model.AccountType,
                //    CreatedAt = DateTime.Now,
                //    CreatedBy = "Admin"
                //}
            };
            // if customer already exists, then indicate  that the password default is false. it is set to true in the customer entity class
            /* if (IsUserExist)
                 customer.DefaultPassword = false;

             if (model.AccountType == (AccountType)1)
                 customer.Account.Balance = 5000;
             else
                 customer.Account.Balance = 0;

             _unitOfWork.Customers.Add(customer);
             _unitOfWork.Commit();

             return customer.Account.AccountNumber;
         }*/

            /*public Customer Get(int Id)
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



            public int Update(UpdateViewModel model, int Id)
            {
                int updatedRow = 0;
                var customer = _unitOfWork.Customers.Get(Id);
                customer.FirstName = model.FirstName ??= customer.FirstName;
                customer.LastName = model.LastName ??= customer.LastName;
                updatedRow = _unitOfWork.Commit();
                return updatedRow;
            
        }*/
        
    }
}
