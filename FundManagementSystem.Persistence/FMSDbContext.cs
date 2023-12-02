using FundManagementSystem.Domain.Common;
using FundManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Persistence
{
    public class FMSDbContext : DbContext
    {
        public FMSDbContext(DbContextOptions<FMSDbContext> options) : base(options)
        {

        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FMSDbContext).Assembly);

            // Seed data
            var clientId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            modelBuilder.Entity<Client>().HasData(new Client
            {
                Id= clientId,
                Name = "Kushi Saranya",
                Email = "kush@gmail.com"
            });

            modelBuilder.Entity<Portfolio>().HasData(new Portfolio
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                ClientId = clientId,
                Name = "Portfolio One",
                Type = "EQUITY",
                StartDate = DateTime.Now,
                EndDate = null
            });

            modelBuilder.Entity<Portfolio>().HasData(new Portfolio
            {
                Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                ClientId = clientId,
                Name = "Portfolio Two",
                Type = "FIXED_INCOME",
                StartDate = DateTime.Now,
                EndDate = null
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
