using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebUI.Domain.Model
{
    public class CreateCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
