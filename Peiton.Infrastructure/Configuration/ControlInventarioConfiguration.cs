using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ControlInventarioConfiguration : IEntityTypeConfiguration<ControlInventario>
{
	public void Configure(EntityTypeBuilder<ControlInventario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ControlInventario");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.EstadoInventarioId).HasColumnName("Fk_EstadoInventario");
		builder.Property(p => p.EstadoAprobacionInventarioId).HasColumnName("Fk_EstadoAprobacionInventario");
		builder.Property(p => p.NombramientoId).HasColumnName("Fk_Nombramiento");
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.ProfesionalId).HasColumnName("Fk_Profesional");

		/*builder.HasOne(d => d.Nombramiento)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.NombramientoId);*/

		/*builder.HasOne(d => d.AprobacionNavigation)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.Aprobacion);*/

		/*builder.HasOne(d => d.EstadoAprobacionInventario)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.EstadoAprobacionInventarioId);*/

		/*builder.HasOne(d => d.EstadoInventario)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.EstadoInventarioId);*/

		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.ControlesInventarios)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
