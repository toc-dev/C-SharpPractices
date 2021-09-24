using OnlineBanking.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace WebUI.domain.Model
{
    public class RegisterCustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please select account type")]
        public AccountType AccountType { get; set; }
        public int AccountNumber { get; set; }
        public decimal? Balance { get; set; }
    }
}
