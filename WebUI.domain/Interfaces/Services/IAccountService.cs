using System;
using System.Collections.Generic;
using System.Text;
//using IdentityServer3.Core.ViewModels;
using OnlineBanking.Domain.Entities;
using WebUI.domain.Models;

namespace WebUI.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Account Get(string accountNumber);
        Account Get(Customer customer);
        public Account Get(Guid Id);
        void checkBalance(User user);
        //Account Register(RegisterViewModel model);
        int Update(UpdateViewModel model);
        //Account Login(LoginViewModel model);
        //(int affectedRow, Account account) Delete(int id);
    };

}
