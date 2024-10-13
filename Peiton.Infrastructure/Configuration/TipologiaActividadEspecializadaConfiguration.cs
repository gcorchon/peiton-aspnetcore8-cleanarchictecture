using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipologiaActividadEspecializadaConfiguration : IEntityTypeConfiguration<TipologiaActividadEspecializada>
{
	public void Configure(EntityTypeBuilder<TipologiaActividadEspecializada> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipologiaActividadEspecializada");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
