using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Controllers
{
    public class TransactionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
