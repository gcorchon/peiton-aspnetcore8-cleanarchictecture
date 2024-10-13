using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TuteladoCompaniaConfiguration : IEntityTypeConfiguration<TuteladoCompania>
{
	public void Configure(EntityTypeBuilder<TuteladoCompania> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.CompaniaId });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.CompaniaId).HasColumnName("Fk_Compania");
		builder.Property(p => p.Numero).HasMaxLength(10);

		/*builder.HasOne(d => d.Compania)
			.WithMany(p => p.TuteladosCompanias)
			.HasForeignKey(d => d.CompaniaId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.TuteladosCompanias)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
