using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class LugarResidenciaConfiguration : IEntityTypeConfiguration<LugarResidencia>
{
	public void Configure(EntityTypeBuilder<LugarResidencia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_LugarResidencia");
		builder.Property(p => p.Descripcion).HasMaxLength(25);
		builder.Property(p => p.CondicionesCentro).IsRequired();
		builder.Property(p => p.CondicionesDomicilio).IsRequired();

	}
}
