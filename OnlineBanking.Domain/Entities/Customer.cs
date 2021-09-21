using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineBanking.Domain.Entities
{
  public  class Customer : IEntity
  {       
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
     
        public string FirstName { get; set; }

        [MaxLength(20)]
        [MinLength(4)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid AccountId { get; set; }    
        public Account Account { get; set; }       
        public bool DefaultPassword { get; set; } = true;

    }
}
