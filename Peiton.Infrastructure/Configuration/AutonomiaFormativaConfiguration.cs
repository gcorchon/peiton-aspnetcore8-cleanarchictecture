using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AutonomiaFormativaConfiguration : IEntityTypeConfiguration<AutonomiaFormativa>
{
	public void Configure(EntityTypeBuilder<AutonomiaFormativa> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AutonomiaFormativa");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
