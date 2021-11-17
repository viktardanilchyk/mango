using CodingChallenge.Core;
using CodingChallenge.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Persistence
{
    public class CreditLineDbContext : DbContext
    {
        public DbSet<CreditLineRequest> CreditLineRequests { get; set; }
        
        public DbSet<CreditLine> CreditLine { get; set; }

        public CreditLineDbContext(DbContextOptions<CreditLineDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CreditLineConfiguration());
            modelBuilder.ApplyConfiguration(new CreditLineRequestConfiguration());
        }
    }
}