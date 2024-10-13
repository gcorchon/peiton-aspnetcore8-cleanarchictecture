using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MensajeConfiguration : IEntityTypeConfiguration<Mensaje>
{
	public void Configure(EntityTypeBuilder<Mensaje> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Mensaje");
		builder.Property(p => p.MensajeId).HasColumnName("Fk_Mensaje");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Usuario_DeId).HasColumnName("Fk_Usuario_De");
		builder.Property(p => p.Usuario_ParaId).HasColumnName("Fk_Usuario_Para");
		builder.Property(p => p.Leido).IsRequired();
		builder.Property(p => p.Archivado).IsRequired();
		builder.Property(p => p.Dias).HasComputedColumnSql("(case when [archivado]=(1) then datediff(day,getdate(),dateadd(day,(90),[FechaLectura])) when [leido]=(1) then datediff(day,getdate(),dateadd(day,(30),[FechaLectura])) else (30) end)", false);
		builder.Property(p => p.CssClass).HasMaxLength(50);

		/*builder.HasOne(d => d.MensajePadre)
			.WithMany(p => p.Mensajes)
			.HasForeignKey(d => d.MensajeId);*/

		/*builder.HasOne(d => d.UsuarioDe)
			.WithMany(p => p.MensajesUsuarioDe)
			.HasForeignKey(d => d.Usuario_DeId);*/

		/*builder.HasOne(d => d.UsuarioPara)
			.WithMany(p => p.MensajesUsuarioPara)
			.HasForeignKey(d => d.Usuario_ParaId);*/

	}
}
