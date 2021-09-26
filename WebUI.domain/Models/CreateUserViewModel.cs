using OnlineBanking.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Domain.Interfaces;

namespace WebUI.domain.Models
{
    public class CreateUserViewModel: IEntity
    {
        [MinLength(4), MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(4), MaxLength(50)]
        public string LastName { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
