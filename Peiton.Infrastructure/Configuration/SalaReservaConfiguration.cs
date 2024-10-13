using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SalaReservaConfiguration : IEntityTypeConfiguration<SalaReserva>
{
	public void Configure(EntityTypeBuilder<SalaReserva> builder)
	{
		builder.HasKey(t => new { t.SalaId, t.Fecha, t.Intervalo });

		builder.Property(p => p.SalaId).HasColumnName("Fk_Sala");
		builder.Property(p => p.Intervalo).HasMaxLength(2);
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");

		/*builder.HasOne(d => d.Sala)
			.WithMany(p => p.SalasReservas)
			.HasForeignKey(d => d.SalaId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.SalasReservas)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
