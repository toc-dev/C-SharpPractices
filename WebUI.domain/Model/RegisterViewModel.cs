using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;

namespace WebUI.domain.Model
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Please select account type")]
        public AccountType AccountType { get; set; }

        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password to continue")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? dateTime { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Kachii";
        public string UpdatedBy { get; set; } = "Sage The Unruly";
        public bool IsActive { get; set; } = true;
    }
}
