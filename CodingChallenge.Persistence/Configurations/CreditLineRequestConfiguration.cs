using CodingChallenge.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingChallenge.Persistence.Configurations
{
    public class CreditLineRequestConfiguration : IEntityTypeConfiguration<CreditLineRequest>
    {
        public void Configure(EntityTypeBuilder<CreditLineRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CreditLine);
        }
    }
}