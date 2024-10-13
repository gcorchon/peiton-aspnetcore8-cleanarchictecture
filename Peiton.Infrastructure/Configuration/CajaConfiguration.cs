using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CajaConfiguration : IEntityTypeConfiguration<Caja>
{
	public void Configure(EntityTypeBuilder<Caja> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Caja");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoPagoId).HasColumnName("Fk_TipoPago");
		builder.Property(p => p.MetodoPagoId).HasColumnName("Fk_MetodoPago");
		builder.Property(p => p.PeriodicidadId).HasColumnName("Fk_Periodicidad");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.Pendiente).IsRequired();
		builder.Property(p => p.CentroId).HasColumnName("Fk_Centro");
		builder.Property(p => p.Anticipo).IsRequired();
		builder.Property(p => p.Recepcion);
		builder.Property(p => p.RecepcionOtro).HasMaxLength(100);
		builder.Property(p => p.ParentescoId).HasColumnName("Fk_Parentesco");
		builder.Property(p => p.PagadorId).HasColumnName("Fk_Pagador");
		builder.Property(p => p.Importe).HasColumnType("money");
		/*builder.HasOne(d => d.MetodoPago)
			.WithMany(p => p.Caja)
			.HasForeignKey(d => d.MetodoPagoId);*/

		/*builder.HasOne(d => d.Parentesco)
			.WithMany(p => p.Caja)
			.HasForeignKey(d => d.ParentescoId);*/

		/*builder.HasOne(d => d.Periodicidad)
			.WithMany(p => p.Caja)
			.HasForeignKey(d => d.PeriodicidadId);*/

		/*builder.HasOne(d => d.TipoPago)
			.WithMany(p => p.Caja)
			.HasForeignKey(d => d.TipoPagoId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.CajaUsuario)
			.HasForeignKey(d => d.UsuarioId);*/

		/*builder.HasOne(d => d.Pagador)
			.WithMany(p => p.CajaPagador)
			.HasForeignKey(d => d.PagadorId);*/

	}
}
