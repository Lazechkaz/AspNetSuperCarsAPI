using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperCarsAPI.Models
{
    public class SuperCarsAPIContext : DbContext
    {
        public SuperCarsAPIContext (DbContextOptions<SuperCarsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SuperCarsAPI.Models.SuperCar> SuperCar { get; set; }
    }
}
