using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PartidaConfiguration : IEntityTypeConfiguration<Partida>
{
	public void Configure(EntityTypeBuilder<Partida> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Partida");
		builder.Property(p => p.CapituloId).HasColumnName("Fk_Capitulo");
		builder.Property(p => p.Numero).HasMaxLength(10);
		builder.Property(p => p.Descripcion).HasMaxLength(255);
		builder.Property(p => p.SaldoInicial).HasColumnType("money").IsRequired();

		builder.HasOne(d => d.Capitulo)
			.WithMany(p => p.Partidas)
			.HasForeignKey(d => d.CapituloId);

	}
}
