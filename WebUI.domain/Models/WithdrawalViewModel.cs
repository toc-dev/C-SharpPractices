using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    public class WithdrawalViewModel
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}