using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.Entities
{
  public  class Customer : IEntity
  {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
  }
}
