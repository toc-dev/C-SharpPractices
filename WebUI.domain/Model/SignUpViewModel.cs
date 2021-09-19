using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Model
{
    public class SignUpViewModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        [Remote(action: "IsEmailUsed", controller: "Account")]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Required]
        public int PlotNo { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password to continue")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}

