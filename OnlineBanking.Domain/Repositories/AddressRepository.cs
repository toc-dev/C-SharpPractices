using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {

        }
    }
}
