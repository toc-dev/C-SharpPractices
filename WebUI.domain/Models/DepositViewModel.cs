using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    public class DepositViewModel
    {
        [Required(ErrorMessage = "Invalid Amount")]
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
    }
}
