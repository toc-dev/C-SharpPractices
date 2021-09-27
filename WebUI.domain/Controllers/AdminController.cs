using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Models;
using WebUI.domain.Utilities;

namespace WebUI.domain.Controllers
{
    [Authorize(Roles = "GrandMaster, Masters")]
    public class AdminController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitofWork;

        public AdminController(RoleManager<AppRole> roleManager,
            UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitofWork = unitOfWork;
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "GrandMaster")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role title does not exist";
                return View("ManageRoles");
            }
            else if (role.Name == "GrandMaster")
            {
                ViewBag.ErrorMessage = "You sneaky fox, nice try but The GrandMaster is going no where!";
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


        [Authorize(Roles = "GrandMaster")]
        public async Task<IActionResult> UpdateRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role data does not exist";
                return RedirectToAction("ManageRoles");
            }
            else if (role.Name == "GrandMaster")
            {
                ViewBag.ErrorMessage = "You sneaky fox, nice try but The GrandMaster is going no where!";
                return View("ManageRoles");
            }
            var model = new UpdateRoleViewModel
            {
                Name = role.Name,
                Id = role.Id
        };

            var users = _userManager.Users;
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    model.Users.Add(user);
            }
            return View(model);
        }


        [Authorize(Roles = "GrandMaster")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            role.UpdatedBy = User.Identity.Name;
            role.UpdatedAt = DateTime.Now;
            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["Success"] = $"Update success: {role.Name} has been updated to roles";
                return RedirectToAction("ManageRoles");
            }
            foreach (var e in result.Errors)
            {
                ModelState.AddModelError("", e.Description);
            }
            return View(model);
        }


        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(model.Email);
                if (userCheck != null)
                {
                    TempData["Alert"] = $"User with {model.Email} already exists";
                    return View();
                }

                var user = new User
                {                    
                    CreatedAt = DateTime.Now,
                    CreatedBy = User.Identity.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    UserName = model.UserName,
                    FullName = $"{model.FirstName} {model.LastName}",
                    Birthday = model.Birthday,
                    Gender = model.Gender,
                    Address = new Address
                    {
                        PlotNo = model.PlotNo,
                        StreetName = model.StreetName,
                        City = model.State,
                        State = model.State,
                        Country = model.Country
                    }
                };

                var password = Tools.PasswordGenerator($"BpOn$43#{model.Email}");
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // if successful send the password to the user's mail.                
                    TempData["Alert2"] = $"Password has been sent to {model.Email}";
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Failed signup Attempt");

            }
            return View(model);
        }


        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (model.Input == null)
            {
                TempData["alert"] = "Odeshi! I know say this na the handwork of Onah.";
                return View("AdminIndex");
            }

            if (model.Options.ToString() == "user")
            {
                User user;
                user = await _userManager.FindByNameAsync(model.Input);
                if (user == null)
                    user = await _userManager.FindByEmailAsync(model.Input);
                if (user == null)
                {
                    TempData["alert"] = "No data found";
                    return View("AdminIndex");
                }
                return View("Search", user);
            }

            if (model.Options.ToString() == "admin")
            {
                User user;
                user = await _userManager.FindByNameAsync(model.Input);
                if (user == null)
                    user = await _userManager.FindByEmailAsync(model.Input);
                if (user == null)
                {
                    TempData["alert"] = "No data found";
                    return View("AdminIndex");
                }
                return View("Search", user);
            }
            return View("AdminIndex");
        }

        /*
                public IActionResult RegisterCustomers()
                {
                    return View();
                }


                [HttpPost]
                [ValidateAntiForgeryToken]
                [AllowAnonymous]
                public async Task<IActionResult> RegisterCustomers(RegisterViewModel model)
                {

                }

                /* Signup to be deleted


                public async Task<IActionResult> SignUp(SignUpViewModel model)
                {

                    if (ModelState.IsValid)
                    {
                        var user = new User
                        {
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            UserName = model.UserName,
                            FullName = $"{model.FirstName} {model.LastName}",
                            Birthday = model.Birthday,
                            Gender = model.Gender,
                            Address = new Address
                            {
                                PlotNo = model.PlotNo,
                                StreetName = model.StreetName,
                                City = model.State,
                                State = model.State,
                                Country = model.Country
                            }
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);

                            return RedirectToAction("index", "Home"); 
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        ModelState.AddModelError(string.Empty, "Failed signup Attempt");

                    }
                    return View(model);
                }

                [AcceptVerbs("Get", "Post")]
                        [AllowAnonymous]
                        public async Task<IActionResult> IsEmailUsed(string email)
                        {
                            var user = await _userManager.FindByEmailAsync(email);
                            if (user == null)
                                return Json(true);
                            return Json($"{email} already exists");
                        }*/

        /*public async Task<IActionResult>  EnrollUser(CreateUserViewModel model)
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
        }*/
    }
}
