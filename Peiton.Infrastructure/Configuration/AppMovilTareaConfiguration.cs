using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilTareaConfiguration : IEntityTypeConfiguration<AppMovilTarea>
{
	public void Configure(EntityTypeBuilder<AppMovilTarea> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilTarea");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoObjetivoId).HasColumnName("Fk_TipoObjetivo");
		builder.Property(p => p.ObjetivoSocialId).HasColumnName("Fk_ObjetivoSocial");
		builder.Property(p => p.AppMovilTipoTareaId).HasColumnName("Fk_AppMovilTipoTarea");
		builder.Property(p => p.AppMovilPeriodicidadId).HasColumnName("Fk_AppMovilPeriodicidad");
		builder.Property(p => p.AppMovilCumplimientoId).HasColumnName("Fk_AppMovilCumplimiento");

		/*builder.HasOne(d => d.AppMovilCumplimiento)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.AppMovilCumplimientoId);*/

		/*builder.HasOne(d => d.AppMovilPeriodicidad)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.AppMovilPeriodicidadId);*/

		/*builder.HasOne(d => d.AppMovilTipoTarea)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.AppMovilTipoTareaId);*/

		/*builder.HasOne(d => d.ObjetivoSocial)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.ObjetivoSocialId);*/

		/*builder.HasOne(d => d.TipoObjetivo)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.TipoObjetivoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.AppMovilTareas)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
