using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ProcedimientoAdicionalConfiguration : IEntityTypeConfiguration<ProcedimientoAdicional>
{
	public void Configure(EntityTypeBuilder<ProcedimientoAdicional> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.ProcedimientoId).HasColumnName("Fk_Procedimiento");
		builder.Property(p => p.NumeroProcedimiento).HasMaxLength(50);
		builder.Property(p => p.AbogadoExternoId).HasColumnName("Fk_AbogadoExterno");
		builder.Property(p => p.AbogadoInternoId).HasColumnName("Fk_AbogadoInterno");
		builder.Property(p => p.Terminado).IsRequired();
		builder.Property(p => p.OrdenJurisdiccionalId).HasColumnName("Fk_OrdenJurisdiccional");

		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.ProcedimientosAdicionales)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.Procedimiento)
			.WithMany(p => p.ProcedimientosAdicionales)
			.HasForeignKey(d => d.ProcedimientoId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.ProcedimientosAdicionales)
			.HasForeignKey(d => d.TuteladoId);


		builder.Navigation(p => p.Juzgado).AutoInclude();

	}
}
