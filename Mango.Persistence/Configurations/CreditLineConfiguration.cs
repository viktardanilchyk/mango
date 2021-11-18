using Mango.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mango.Persistence.Configurations
{
    public class CreditLineConfiguration : IEntityTypeConfiguration<CreditLine>
    {
        public void Configure(EntityTypeBuilder<CreditLine> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}