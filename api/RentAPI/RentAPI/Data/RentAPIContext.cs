using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentAPI.Models;

namespace RentAPI.Data
{
    public class RentAPIContext : DbContext
    {
        public RentAPIContext (DbContextOptions<RentAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RentAPI.Models.BikeModel> BikeModel { get; set; }
    }
}
