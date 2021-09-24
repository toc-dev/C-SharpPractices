using Microsoft.AspNetCore.Identity;
using OnlineBanking.Domain.Enumerators;
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
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }   

}
