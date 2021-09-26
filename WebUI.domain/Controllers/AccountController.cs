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
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]        
        public async Task<IActionResult> LogIn(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user,"GrandMaster") || await _userManager.IsInRoleAsync(user,"Masters"))
                {
                    TempData["WelcomeMsg"] = $"Welcome Back Admin@{user.UserName}.";
                    return RedirectToAction("AdminIndex", "Admin");
                }                    
                
                else if (!string.IsNullOrEmpty(returnUrl))                
                    return LocalRedirect(returnUrl);                
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            }
            if (result.IsLockedOut)
            {
                // _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
