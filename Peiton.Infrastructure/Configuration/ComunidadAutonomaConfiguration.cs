using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ComunidadAutonomaConfiguration : IEntityTypeConfiguration<ComunidadAutonoma>
{
	public void Configure(EntityTypeBuilder<ComunidadAutonoma> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_ComunidadAutonoma");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
