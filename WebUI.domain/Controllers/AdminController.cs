using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(RoleManager<AppRole> roleManager,
            UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole _role = new AppRole
                {
                    Name = model.RoleName,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Kachi"
                };
                var result = await _roleManager.CreateAsync(_role);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCustomer(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                TempData["ErrorMsg"] = "Please input a valid email";
                return View();
            }

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                TempData["ErrorMsg"] = $"{userEmail} does not exist";
                return View();
            }

            var address = await _unitOfWork.Addresses.GetAsync(user.AddressId);
            var nameArray = user.FullName.Split(" ");
            var model = new RegisterCustomerViewModel
            {
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                PlotNo = address.PlotNo,
                StreetName = address.StreetName,
                City = address.City,
                State = address.State,
                LastName = nameArray[1],
                FirstName = nameArray[0],
                Email = user.Email,
                Gender = user.Gender,
                Birthday = user.Birthday,
                Country = address.Country,
                CreatedBy = "Kachi",
                CreatedAt = DateTime.Now
            };
            if (user.Birthday != null)
                model.Age = (DateTime.Now.Year - user.Birthday.Year);

            return View(model);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            
            var user = new User
            {
                UserName = model.UserName,
                FullName = $"{model.FirstName} {model.LastName}",
                Email = model.Email,
                Birthday = model.Birthday,
                Gender = model.Gender,
                CreatedBy = "Kachi",
                CreatedAt = DateTime.Now,
                PhoneNumber = model.PhoneNumber,      
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
        }*/
    }
}


