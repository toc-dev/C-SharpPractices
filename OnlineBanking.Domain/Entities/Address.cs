using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineBanking.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlotNo { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string StreetName { get; set; }

        [Required, MaxLength(30), MinLength(3)]
        public string City { get; set; }

        [Required, MaxLength(30), MinLength(3)]
        public string State { get; set; }

        [Required, MaxLength(30), MinLength(3)]
        public string Country { get; set; }
                
    }
}

/* Bonus work to allow linking to all customers that use a particular address: Kachi note
public int CustomerId { get; set; }

public Customer Customers { get; set; }
*/