using System;
using System.ComponentModel.DataAnnotations;
using OnlineBanking.Domain.Enumerators;

namespace WebUI.domain.Models
{
    public class EnrollCustomerViewModel : CreateUserViewModel
    {
        public AccountType AccountType { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

    }
}