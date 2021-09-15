using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer3.Core.ViewModels;
using OnlineBanking.Domain.Entities;
using WebUI.domain.Model;
using WebUI.Domain.Model;

namespace WebUI.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Account Get(int userId);
        void checkBalance(User user);
        Account Register(RegisterViewModel model);
        int Update(UpdateViewModel model, int Id);
        Account Login(LoginViewModel model);
        (int affectedRow, Account account) Delete(int id);
    };

}
