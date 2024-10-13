using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilRegistroDiarioConfiguration : IEntityTypeConfiguration<AppMovilRegistroDiario>
{
	public void Configure(EntityTypeBuilder<AppMovilRegistroDiario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilRegistroDiario");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.AppMovilEstadoAnimoId).HasColumnName("Fk_AppMovilEstadoAnimo");
		builder.Property(p => p.Selfie).HasMaxLength(255);

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.AppMovilRegistrosDiarios)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.AppMovilEstadoAnimo)
			.WithMany(p => p.AppMovilRegistrosDiarios)
			.HasForeignKey(d => d.AppMovilEstadoAnimoId);*/

	}
}
