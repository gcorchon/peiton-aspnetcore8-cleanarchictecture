using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class IncidenciaEstadoConfiguration : IEntityTypeConfiguration<IncidenciaEstado>
{
	public void Configure(EntityTypeBuilder<IncidenciaEstado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_IncidenciaEstado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
