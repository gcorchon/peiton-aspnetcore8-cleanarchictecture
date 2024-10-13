using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TransferenciaUsuarioConfiguration : IEntityTypeConfiguration<TransferenciaUsuario>
{
	public void Configure(EntityTypeBuilder<TransferenciaUsuario> builder)
	{
		builder.HasKey(t => new { t.UsuarioId, t.EntidadFinancieraId });

		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera").HasDefaultValueSql("((10))");

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.TransferenciasUsuarios)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
