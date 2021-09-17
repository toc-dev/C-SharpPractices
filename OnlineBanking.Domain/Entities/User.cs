using Microsoft.AspNetCore.Identity;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineBanking.Domain.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }

}
