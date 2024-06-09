using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UrgenciaFondoSolidarioConfiguration : IEntityTypeConfiguration<UrgenciaFondoSolidario>
	{
		public void Configure(EntityTypeBuilder<UrgenciaFondoSolidario> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_UrgenciaFondo");
			builder.Property(p => p.UrgenciaId).HasColumnName("Fk_Urgencia");
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
			builder.Property(p => p.UrgenciaFondoSolidarioPadreId).HasColumnName("Fk_UrgenciaFondoSolidarioPadre");
			builder.Property(p => p.Importe).HasColumnType("money").IsRequired();

			/*builder.HasOne(d => d.FondoSolidarioDestino)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.FondoSolidarioDestinoId);*/

			/*builder.HasOne(d => d.FondoSolidarioFormaPago)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.FondoSolidarioFormaPagoId);*/

			/*builder.HasOne(d => d.FondoSolidarioPeriodicidad)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.FondoSolidarioPeriodicidadId);*/

			/*builder.HasOne(d => d.FondoSolidarioTipoFondo)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.FondoSolidarioTipoFondoId);*/

			/*builder.HasOne(d => d.Urgencia)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.UrgenciaId);*/

			/*builder.HasOne(d => d.Revisor)
				.WithMany(p => p.UrgenciasFondosSolidariosRevisor)
				.HasForeignKey(d => d.RevisorId);*/

			/*builder.HasOne(d => d.Autorizador)
				.WithMany(p => p.UrgenciasFondosSolidariosAutorizador)
				.HasForeignKey(d => d.AutorizadorId);*/

			/*builder.HasOne(d => d.Solicitante)
				.WithMany(p => p.UrgenciasFondosSolidariosSolicitante)
				.HasForeignKey(d => d.SolicitanteId);*/

			/*builder.HasOne(d => d.Pagador)
				.WithMany(p => p.UrgenciasFondosSolidariosPagador)
				.HasForeignKey(d => d.PagadorId);*/

			/*builder.HasOne(d => d.FondoSolidarioTarjetaPrepago)
				.WithMany(p => p.UrgenciasFondosSolidarios)
				.HasForeignKey(d => d.FondoSolidarioTarjetaPrepagoId);*/

			/*builder.HasOne(d => d.Verificador)
				.WithMany(p => p.UrgenciasFondosSolidariosVerificador)
				.HasForeignKey(d => d.VerificadorId);*/

		}
	}
}