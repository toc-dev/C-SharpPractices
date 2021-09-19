using Microsoft.AspNetCore.Identity;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }

}
