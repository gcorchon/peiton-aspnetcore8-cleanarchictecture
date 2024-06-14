using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
	public class CajaIncidenciaConfiguration : IEntityTypeConfiguration<CajaIncidencia>
	{
		public void Configure(EntityTypeBuilder<CajaIncidencia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_CajaIncidencia");
			builder.Property(p => p.CajaId).HasColumnName("Fk_Caja");
			builder.Property(p => p.FechaIncidencia).HasDefaultValueSql("(getdate())");
			builder.Property(p => p.RazonIncidenciaCajaId).HasColumnName("Fk_RazonIncidenciaCaja");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.TipoPagoId).HasColumnName("Fk_TipoPago");
			builder.Property(p => p.MetodoPagoId).HasColumnName("Fk_MetodoPago");
			builder.Property(p => p.PeriodicidadId).HasColumnName("Fk_Periodicidad");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.CentroId).HasColumnName("Fk_Centro");
			builder.Property(p => p.RecepcionOtro).HasMaxLength(100);
			builder.Property(p => p.ParentescoId).HasColumnName("Fk_Parentesco");
			builder.Property(p => p.Importe).HasColumnType("money");

			builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.TuteladoId);

			/*builder.HasOne(d => d.MetodoPago)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.MetodoPagoId);*/

			/*builder.HasOne(d => d.Parentesco)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.ParentescoId);*/

			/*builder.HasOne(d => d.Periodicidad)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.PeriodicidadId);*/

			/*builder.HasOne(d => d.TipoPago)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.TipoPagoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.UsuarioId);*/

			/*builder.HasOne(d => d.RazonIncidenciaCaja)
				.WithMany(p => p.CajaIncidencias)
				.HasForeignKey(d => d.RazonIncidenciaCajaId);*/

		}
	}
}