using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SenalamientoConfiguration : IEntityTypeConfiguration<Senalamiento>
{
	public void Configure(EntityTypeBuilder<Senalamiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Senalamiento");
		builder.Property(p => p.Procedimiento).HasMaxLength(50);
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.AbogadoAsistenteId).HasColumnName("Fk_AbogadoAsistente");
		builder.Property(p => p.AbogadoAsignadoId).HasColumnName("Fk_AbogadoAsignado");
		builder.Property(p => p.Tutelado).HasMaxLength(50);
		builder.Property(p => p.ProfesionalAsistente).HasMaxLength(50);
		builder.Property(p => p.MadridCapital).IsRequired();

		/*builder.HasOne(d => d.AbogadoAsistente)
			.WithMany(p => p.Senalamientos)
			.HasForeignKey(d => d.AbogadoAsistenteId);*/

		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.Senalamientos)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.TuteladoNavigation)
			.WithMany(p => p.Senalamientos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
