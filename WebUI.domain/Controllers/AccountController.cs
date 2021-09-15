using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult SignUp()
        {
            return View();
        }
    }
}
