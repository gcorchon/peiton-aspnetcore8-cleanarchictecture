using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ControlRendicionConfiguration : IEntityTypeConfiguration<ControlRendicion>
{
	public void Configure(EntityTypeBuilder<ControlRendicion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ControlRendicion");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoRendicionId).HasColumnName("Fk_TipoRendicion");
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.NombramientoId).HasColumnName("Fk_Nombramiento");
		builder.Property(p => p.EstadoAprobacionRendicionId).HasColumnName("Fk_EstadoAprobacionRendicion");
		builder.Property(p => p.TipoAprobacionRendicionId).HasColumnName("Fk_TipoAprobacionRendicion");
		builder.Property(p => p.EstadoRetribucionId).HasColumnName("Fk_EstadoRetribucion");
		builder.Property(p => p.Cuenta).HasMaxLength(25);
		builder.Property(p => p.OtraCuenta).HasMaxLength(25);
		builder.Property(p => p.ArchivoRendicionId).HasColumnName("Fk_ArchivoRendicion");
		builder.Property(p => p.ArchivoAprobacionId).HasColumnName("Fk_ArchivoAprobacion");
		builder.Property(p => p.RendimientoLiquido).HasColumnType("money");
		builder.Property(p => p.Importe).HasColumnType("money");
		builder.Property(p => p.ImporteReal).HasColumnType("money");
		builder.Property(p => p.Porcentaje).HasColumnType("money");
		/*builder.HasOne(d => d.ArchivoAprobacion)
			.WithMany(p => p.ControlesRendicionesArchivoAprobacion)
			.HasForeignKey(d => d.ArchivoAprobacionId);*/

		/*builder.HasOne(d => d.ArchivoRendicion)
			.WithMany(p => p.ControlesRendicionesArchivoRendicion)
			.HasForeignKey(d => d.ArchivoRendicionId);*/

		/*builder.HasOne(d => d.EstadoAprobacionRendicion)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.EstadoAprobacionRendicionId);*/

		/*builder.HasOne(d => d.EstadoRetribucion)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.EstadoRetribucionId);*/

		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.Nombramiento)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.NombramientoId);*/

		/*builder.HasOne(d => d.TipoAprobacionRendicion)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.TipoAprobacionRendicionId);*/

		/*builder.HasOne(d => d.TipoRendicion)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.TipoRendicionId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.ControlesRendiciones)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
