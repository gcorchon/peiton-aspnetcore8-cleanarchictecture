using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AccountCPValidaConfiguration : IEntityTypeConfiguration<AccountCPValida>
	{
		public void Configure(EntityTypeBuilder<AccountCPValida> builder)
		{
			builder.HasKey(t => t.Iban);

			builder.Property(p => p.Iban).ValueGeneratedNever().HasMaxLength(12);

		}
	}
}