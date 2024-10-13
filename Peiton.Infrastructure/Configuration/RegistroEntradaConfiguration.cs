using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RegistroEntradaConfiguration : IEntityTypeConfiguration<RegistroEntrada>
{
	public void Configure(EntityTypeBuilder<RegistroEntrada> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_RegistroEntrada");
		builder.Property(p => p.Dni).HasMaxLength(20);
		builder.Property(p => p.Nombre).HasMaxLength(50);
		builder.Property(p => p.MotivoEntradaId).HasColumnName("Fk_MotivoEntrada");
		builder.Property(p => p.HoraEntrada).HasMaxLength(2);
		builder.Property(p => p.HoraSalida).HasMaxLength(2);

		/*builder.HasOne(d => d.MotivoEntrada)
			.WithMany(p => p.RegistrosEntradas)
			.HasForeignKey(d => d.MotivoEntradaId);*/

	}
}
