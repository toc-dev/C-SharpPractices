using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Model
{
    public class RegisterCustomerViewModel
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select account type")]
        public AccountType AccountType { get; set; }
        public int AccountNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? dateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
