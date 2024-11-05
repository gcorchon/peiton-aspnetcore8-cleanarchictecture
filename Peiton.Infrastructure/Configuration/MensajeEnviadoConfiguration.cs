using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MensajeEnviadoConfiguration : IEntityTypeConfiguration<MensajeEnviado>
{
	public void Configure(EntityTypeBuilder<MensajeEnviado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_MensajeEnviado");
		builder.Property(p => p.MensajeId).HasColumnName("Fk_Mensaje");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Usuario_DeId).HasColumnName("Fk_Usuario_De");
		builder.Property(p => p.Dias).HasComputedColumnSql("(datediff(day,getdate(),dateadd(day,(30),[Fecha])))", false);

		/*
				builder.HasOne(d => d.Mensaje)
					.WithMany(p => p.MensajesEnviados)
					.HasForeignKey(d => d.MensajeId);
		*/

		builder.HasOne(d => d.UsuarioDe)
			.WithMany(p => p.MensajesEnviados2)
			.HasForeignKey(d => d.Usuario_DeId);

	}
}
