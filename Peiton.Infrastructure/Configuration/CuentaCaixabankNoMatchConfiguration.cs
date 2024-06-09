using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CuentaCaixabankNoMatchConfiguration : IEntityTypeConfiguration<CuentaCaixabankNoMatch>
	{
		public void Configure(EntityTypeBuilder<CuentaCaixabankNoMatch> builder)
		{
			builder.HasKey(t => t.IBAN);

			builder.Property(p => p.IBAN).ValueGeneratedNever().HasMaxLength(255);
			builder.Property(p => p.Nombre).HasMaxLength(255);

		}
	}
}