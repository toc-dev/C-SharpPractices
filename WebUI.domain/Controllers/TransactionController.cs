using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using OnlineBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Models;

namespace WebUI.domain.Controllers
{
    public class TransactionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRepository<Account> _repository;
        public TransactionController(IRepository<Account> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Withdrawal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Withdrawal(WithdrawalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userAcc = _repository.Find(a => a.AccountNumber == model.AccountNumber).FirstOrDefault();
            if (userAcc == null)
            {
                ModelState.AddModelError("", "Account number not found!");
                return View();
            }
            if (!userAcc.IsActive)
            {
                ModelState.AddModelError("", "Your account has been inactive. Please reactivate and try again");
            }
            
            var userBalance = userAcc.Balance;
            if (model.Amount > userBalance)
            {
                ModelState.AddModelError("", "Insufficient funds");
            }
            var newBal = userBalance - model.Amount;
            var account = new Account
            {
                Balance = newBal,
                UpdatedAt = DateTime.Now
            };
            _repository.Update(account);
            
            return View();
        }
    }
}
