using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RequerimientoConfiguration : IEntityTypeConfiguration<Requerimiento>
{
	public void Configure(EntityTypeBuilder<Requerimiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Requerimiento");
		builder.Property(c => c.NumeroProcedimiento).HasMaxLength(255);
		builder.Property(c => c.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(c => c.ArchivoRequerimientoId).HasColumnName("Fk_ArchivoRequerimiento");
		builder.Property(c => c.ContestacionRequerimientoId).HasColumnName("Fk_ContestacionRequerimiento");
		builder.Property(c => c.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(c => c.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(c => c.RequerimientoDetalleId).HasColumnName("Fk_RequerimientoDetalle");
		builder.Property(c => c.RequerimientoOrigenId).HasColumnName("Fk_RequerimientoOrigen");
		builder.Property(c => c.RequerimientoTipoId).HasColumnName("Fk_RequerimientoTipo");
	}
}
