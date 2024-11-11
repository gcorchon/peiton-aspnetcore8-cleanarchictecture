using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class OtroAsuntoConfiguration : IEntityTypeConfiguration<OtroAsunto>
{
	public void Configure(EntityTypeBuilder<OtroAsunto> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.OtroAsuntoTipoId).HasColumnName("Fk_OtroAsuntoTipo");
		builder.Property(p => p.AbogadoExternoId).HasColumnName("Fk_AbogadoExterno");
		builder.Property(p => p.AbogadoInternoId).HasColumnName("Fk_AbogadoInterno");

		/*builder.HasOne(d => d.AbogadoInterno)
			.WithMany(p => p.OtrosAsuntos)
			.HasForeignKey(d => d.AbogadoInternoId);*/

		/*builder.HasOne(d => d.AbogadoExterno)
			.WithMany(p => p.OtrosAsuntos)
			.HasForeignKey(d => d.AbogadoExternoId);*/

		/*builder.HasOne(d => d.OtroAsuntoTipo)
			.WithMany(p => p.OtrosAsuntos)
			.HasForeignKey(d => d.OtroAsuntoTipoId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.OtrosAsuntos)
			.HasForeignKey(d => d.TuteladoId);

	}
}
