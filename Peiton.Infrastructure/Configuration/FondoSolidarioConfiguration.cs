using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FondoSolidarioConfiguration : IEntityTypeConfiguration<FondoSolidario>
{
	public void Configure(EntityTypeBuilder<FondoSolidario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidario");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.FondoSolidarioTipoFondoId).HasColumnName("Fk_FondoSolidarioTipoFondo");
		builder.Property(p => p.FondoSolidarioPeriodicidadId).HasColumnName("Fk_FondoSolidarioPeriodicidad");
		builder.Property(p => p.FondoSolidarioDestinoId).HasColumnName("Fk_FondoSolidarioDestino");
		builder.Property(p => p.FondoSolidarioFormaPagoId).HasColumnName("Fk_FondoSolidarioFormaPago");
		builder.Property(p => p.SolicitanteId).HasColumnName("Fk_Solicitante");
		builder.Property(p => p.RevisorId).HasColumnName("Fk_Revisor");
		builder.Property(p => p.AutorizadorId).HasColumnName("Fk_Autorizador");
		builder.Property(p => p.PagadorId).HasColumnName("Fk_Pagador");
		builder.Property(p => p.VerificadorId).HasColumnName("Fk_Verificador");
		builder.Property(p => p.Archivo).HasMaxLength(255);
		builder.Property(p => p.Revisado).IsRequired();
		builder.Property(p => p.Autorizado).IsRequired();
		builder.Property(p => p.Pagado).IsRequired();
		builder.Property(p => p.Verificado).IsRequired();
		builder.Property(p => p.Rechazado).IsRequired();
		builder.Property(p => p.Recuperable).IsRequired();
		builder.Property(p => p.FondoSolidarioTarjetaPrepagoId).HasColumnName("Fk_FondoSolidarioTarjetaPrepago");
		builder.Property(p => p.Archivo2).HasMaxLength(255);
		builder.Property(p => p.FondoSolidarioPadreId).HasColumnName("Fk_FondoSolidarioPadre");
		builder.Property(p => p.Importe).HasColumnType("money");

		//builder.Navigation(p => p.FondoSolidarioDestino).AutoInclude();
		//builder.Navigation(p => p.Solicitante).AutoInclude();

		/*builder.HasOne(d => d.FondoSolidarioDestino)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.FondoSolidarioDestinoId);*/

		/*builder.HasOne(d => d.FondoSolidarioFormaPago)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.FondoSolidarioFormaPagoId);*/

		/*builder.HasOne(d => d.FondoSolidarioPeriodicidad)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.FondoSolidarioPeriodicidadId);*/

		/*builder.HasOne(d => d.FondoSolidarioTipoFondo)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.FondoSolidarioTipoFondoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Revisor)
			.WithMany(p => p.FondosSolidariosRevisor)
			.HasForeignKey(d => d.RevisorId);*/

		/*builder.HasOne(d => d.Autorizador)
			.WithMany(p => p.FondosSolidariosAutorizador)
			.HasForeignKey(d => d.AutorizadorId);*/

		/*builder.HasOne(d => d.Solicitante)
			.WithMany(p => p.FondosSolidariosSolicitante)
			.HasForeignKey(d => d.SolicitanteId);*/

		/*builder.HasOne(d => d.Pagador)
			.WithMany(p => p.FondosSolidariosPagador)
			.HasForeignKey(d => d.PagadorId);*/

		/*builder.HasOne(d => d.FondoSolidarioTarjetaPrepago)
			.WithMany(p => p.FondosSolidarios)
			.HasForeignKey(d => d.FondoSolidarioTarjetaPrepagoId);*/

		/*builder.HasOne(d => d.Verificador)
			.WithMany(p => p.FondosSolidariosVerificador)
			.HasForeignKey(d => d.VerificadorId);*/

	}
}
