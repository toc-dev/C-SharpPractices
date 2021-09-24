using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Model
{
    public class SignUpViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? dateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}