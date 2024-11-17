using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
{
	public void Configure(EntityTypeBuilder<Prestamo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Prestamo");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoPrestamoId).HasColumnName("Fk_TipoPrestamo");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.Porcentaje).HasMaxLength(5);
		builder.Property(p => p.Baja);
		builder.Property(p => p.Numero).HasMaxLength(50);
		builder.Property(p => p.Pendiente).HasColumnType("money");
		builder.Property(p => p.Inicial).HasColumnType("money");
		builder.Property(p => p.Cuota).HasColumnType("money");

		builder.Navigation(p => p.EntidadFinanciera).AutoInclude();
		builder.Navigation(p => p.TipoPrestamo).AutoInclude();

		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.Prestamos)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

		/*builder.HasOne(d => d.TipoPrestamo)
			.WithMany(p => p.Prestamos)
			.HasForeignKey(d => d.TipoPrestamoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Prestamos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
