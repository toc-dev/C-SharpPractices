using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Model;

namespace WebUI.domain.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppRole _role;

        public AdminController(RoleManager<IdentityRole> roleManager, AppRole role)
        {
            _roleManager = roleManager;
            _role = role;
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            ViewBag.Title = "Create Role";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
                _role.Name = model.RoleName;
            var result = await _roleManager.CreateAsync(_role);
            if (result.Succeeded)
                return RedirectToAction("index", "Home"); 
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
