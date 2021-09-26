using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Models;

namespace WebUI.domain.Controllers
{
    [Authorize(Roles = "GrandMaster, Masters")]
    public class AdminController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        [Authorize(Roles = "GrandMaster")]
        public IActionResult ManageRoles()
        {
            return View();
        }

        [Authorize(Roles = "GrandMaster")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "GrandMaster")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole _role = new AppRole
                {
                    Name = model.RoleName,
                    CreatedAt = DateTime.Now,
                    CreatedBy = User.Identity.Name
                };
                var roleCheck = await _roleManager.RoleExistsAsync(_role.Name);

                if (roleCheck)
                {
                    TempData["RoleExistsMsg"] = "Role already exists";
                    return View();
                }
                    
                var result = await _roleManager.CreateAsync(_role);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Role has been created";
                    return View();
                }

                foreach (var error in result.Errors)                
                    ModelState.AddModelError("", error.Description);                
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "GrandMaster")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role title does not exist";
                return View("ManageRoles");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ManageRoles");
                }

                foreach (var error in result.Errors)                
                    ModelState.AddModelError("", error.Description);
                
                return View("ManageRoles");
            }
        }



    }
}
