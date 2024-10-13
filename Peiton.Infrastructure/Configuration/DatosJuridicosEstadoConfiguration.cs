using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DatosJuridicosEstadoConfiguration : IEntityTypeConfiguration<DatosJuridicosEstado>
{
	public void Configure(EntityTypeBuilder<DatosJuridicosEstado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_DatosJuridicosEstado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
