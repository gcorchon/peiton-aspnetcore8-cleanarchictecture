using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ResidenciaHabitualHistoricoConfiguration : IEntityTypeConfiguration<ResidenciaHabitualHistorico>
{
	public void Configure(EntityTypeBuilder<ResidenciaHabitualHistorico> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ResidenciaHabitualHistorico");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Tipo).HasMaxLength(0);
		builder.Property(p => p.CentroId).HasColumnName("Fk_Centro");
		builder.Property(p => p.TipoCentroId).HasColumnName("Fk_TipoCentro");
		builder.Property(p => p.TipoFinanciacionId).HasColumnName("Fk_TipoFinanciacion");
		builder.Property(p => p.TipoFinanciacionPublicaId).HasColumnName("Fk_TipoFinanciacionPublica");
		builder.Property(p => p.TipoViaId).HasColumnName("Fk_TipoVia");
		builder.Property(p => p.Direccion).HasMaxLength(100);
		builder.Property(p => p.Numero).HasMaxLength(10);
		builder.Property(p => p.Portal).HasMaxLength(10);
		builder.Property(p => p.Escalera).HasMaxLength(10);
		builder.Property(p => p.Piso).HasMaxLength(10);
		builder.Property(p => p.Puerta).HasMaxLength(10);
		builder.Property(p => p.CodigoPostal).HasMaxLength(10);
		builder.Property(p => p.Municipio).HasMaxLength(50);
		builder.Property(p => p.ProvinciaId).HasColumnName("Fk_Provincia");
		builder.Property(p => p.Telefono1).HasMaxLength(20);
		builder.Property(p => p.Telefono2).HasMaxLength(20);
		builder.Property(p => p.DistritoId).HasColumnName("Fk_Distrito");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

		/*builder.HasOne(d => d.Centro)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.CentroId);*/

		/*builder.HasOne(d => d.Distrito)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.DistritoId);*/

		/*builder.HasOne(d => d.Provincia)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.ProvinciaId);*/

		/*builder.HasOne(d => d.TipoCentro)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.TipoCentroId);*/

		/*builder.HasOne(d => d.TipoFinanciacionPublica)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.TipoFinanciacionPublicaId);*/

		/*builder.HasOne(d => d.TipoVia)
			.WithMany(p => p.ResidenciasHabitualesHistoricos)
			.HasForeignKey(d => d.TipoViaId);*/

	}
}
