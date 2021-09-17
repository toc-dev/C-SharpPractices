using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineBanking.Domain.Enumerators;
using OnlineBanking.Domain.Interfaces;

namespace OnlineBanking.Domain.Entities
{
   public class Account: IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public int? UserId { get; set; }

        public int CustomerId { get; set; }
                
        public int AccountNumber { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }

        public AccountType AccountType { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }           
               
    }

}