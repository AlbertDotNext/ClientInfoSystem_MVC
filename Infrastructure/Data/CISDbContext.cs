using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(ConfigureClient);
            modelBuilder.Entity<Interatction>(ConfigureInteraction);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(e => e.Password).HasMaxLength(10).HasColumnType("varchar");
            builder.Property(e => e.Designation).HasMaxLength(50).HasColumnType("varchar");
        }
        private void ConfigureInteraction(EntityTypeBuilder<Interatction> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.EmpId).IsRequired(false);
            builder.Property(i => i.ClientId).IsRequired(false);
            builder.Property(i => i.IntType).HasMaxLength(1).HasColumnType("char");
            builder.Property(i => i.IntDate).HasColumnType("datetime");
            builder.Property(i => i.Remarks).HasMaxLength(500).HasColumnType("varchar");

        }
        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(c => c.Email).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(c => c.Phones).HasMaxLength(30).HasColumnType("varchar");
            builder.Property(c => c.Address).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(c => c.AddedOn).IsRequired(false);
        }
    }
}
