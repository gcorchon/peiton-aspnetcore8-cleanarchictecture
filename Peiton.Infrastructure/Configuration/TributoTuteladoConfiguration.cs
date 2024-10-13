using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TributoTuteladoConfiguration : IEntityTypeConfiguration<TributoTutelado>
{
	public void Configure(EntityTypeBuilder<TributoTutelado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TributoTutelado");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TributoId).HasColumnName("Fk_Tributo");
		builder.Property(p => p.TributoPeriodicidadId).HasColumnName("Fk_TributoPeriodicidad");
		builder.Property(p => p.TributoEstadoId).HasColumnName("Fk_TributoEstado");
		builder.Property(p => p.TributoSubestadoId).HasColumnName("Fk_TributoSubestado");
		builder.Property(p => p.Baja).IsRequired();
		builder.Property(p => p.Matricula).HasMaxLength(20);
		builder.Property(p => p.Importe).HasColumnType("money");
		/*builder.HasOne(d => d.Tributo)
			.WithMany(p => p.TributosTutelados)
			.HasForeignKey(d => d.TributoId);*/

		/*builder.HasOne(d => d.TributoEstado)
			.WithMany(p => p.TributosTutelados)
			.HasForeignKey(d => d.TributoEstadoId);*/

		/*builder.HasOne(d => d.TributoPeriodicidad)
			.WithMany(p => p.TributosTutelados)
			.HasForeignKey(d => d.TributoPeriodicidadId);*/

		/*builder.HasOne(d => d.TributoSubestado)
			.WithMany(p => p.TributosTutelados)
			.HasForeignKey(d => d.TributoSubestadoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.TributosTutelados)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
