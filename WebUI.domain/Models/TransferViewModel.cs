using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    public class TransferViewModel
    {
        [Required(ErrorMessage = "Please provide a valid account number")]
        [MinLength(10, ErrorMessage = "Account number must be 10 digits")]
        [MaxLength(10, ErrorMessage = "Account number must be 10 digits")]
        public string RecipientAccountNumber { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Zero amounts are not allowed")]
        [Column(TypeName = "decimal(18,2")]
        public decimal Amount { get; set; }
    }
}
