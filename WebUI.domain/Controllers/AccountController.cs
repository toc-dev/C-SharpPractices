using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Domain.Entities;
using WebUI.domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.domain.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public async Task<IActionResult>  EnrollUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = $"{model.FirstName} {model.LastName}",
                    Email = model.Email,
                    UserName = model.UserName,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Tochukwu"
                };
                var result = await _userManager.CreateAsync(user, "Password@123");
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.AddModelError(string.Empty, "Failed signup Attempt");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
