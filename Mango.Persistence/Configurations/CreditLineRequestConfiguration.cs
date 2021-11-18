using Mango.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mango.Persistence.Configurations
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