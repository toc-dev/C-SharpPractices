using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebUI.Domain.Model
{
    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Birthday required")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string CreatedBy { get; set; }
        public AccountType AccountType { get; set; }
    }
}
