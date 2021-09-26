using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    public class RegisterUserViewModel : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int PlotNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
