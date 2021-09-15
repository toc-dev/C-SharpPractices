using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Model;
using WebUI.Domain.Repositories;

namespace WebUI.domain.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SignUp(RegisterViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                AccountRepository.Add(registerUser);
                return View("Thanks", registerUser);
            }
            else
            {
                return View();
            }
        }
    }
}
