using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ActividadEspecializadaConfiguration : IEntityTypeConfiguration<ActividadEspecializada>
{
	public void Configure(EntityTypeBuilder<ActividadEspecializada> builder)
	{
		builder.HasKey(t => new { t.EntidadGestoraId, t.Orden });

		builder.Property(p => p.EntidadGestoraId).HasColumnName("Fk_EntidadGestora");
		builder.Property(p => p.TipoActividad).HasMaxLength(150);
		builder.Property(p => p.TipologiaActividadEspecializadaId).HasColumnName("Fk_TipologiaActividadEspecializada");
		builder.Property(p => p.NumeroHorasSemanales).HasMaxLength(50);

		/*builder.HasOne(d => d.EntidadGestora)
			.WithMany(p => p.ActividadesEspecializadas)
			.HasForeignKey(d => d.EntidadGestoraId);*/

		/*builder.HasOne(d => d.TipologiaActividadEspecializada)
			.WithMany(p => p.ActividadesEspecializadas)
			.HasForeignKey(d => d.TipologiaActividadEspecializadaId);*/

	}
}
