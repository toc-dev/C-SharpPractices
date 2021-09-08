﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.UnitOfWork;
using WebUI.Domain.Model;
using WebUI.Domain.Services;

namespace WebUI.domain.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CustomerForm(CreateCustomerViewModel model)
        {
            
            var customerService = new CustomerService(new UnitOfWork(new AppDbContext()));

            if (ModelState.IsValid)
            {
                customerService.CreateCustomer(model);
                return View("index");
            }
            return View();
        }
    }
}
