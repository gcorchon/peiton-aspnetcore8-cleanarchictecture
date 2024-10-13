using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SchoberConfiguration : IEntityTypeConfiguration<Schober>
{
	public void Configure(EntityTypeBuilder<Schober> builder)
	{
		builder.HasKey(t => t.CodSchober);

		builder.Property(p => p.CodSchober).ValueGeneratedNever().HasMaxLength(2);
		builder.Property(p => p.Description).HasMaxLength(255);

	}
}
