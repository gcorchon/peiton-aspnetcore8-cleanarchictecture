using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RuleConfiguration : IEntityTypeConfiguration<Rule>
	{
		public void Configure(EntityTypeBuilder<Rule> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Rule");

		}
	}
}