using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    public class UpdateViewModel: RegisterUserViewModel
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public AccountType? AccountType { get; set; }
    }
}
