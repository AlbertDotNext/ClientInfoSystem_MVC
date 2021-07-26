using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CISDbContext : DbContext
    {
        public CISDbContext(DbContextOptions<CISDbContext> options) : base(options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Interatction> Interatctions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
