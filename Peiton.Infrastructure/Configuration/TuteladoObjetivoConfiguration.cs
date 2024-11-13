using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TuteladoObjetivoConfiguration : IEntityTypeConfiguration<TuteladoObjetivo>
{
	public void Configure(EntityTypeBuilder<TuteladoObjetivo> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.TipoObjetivoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoObjetivoId).HasColumnName("Fk_TipoObjetivo");
		builder.Property(p => p.ObjetivoSocialId).HasColumnName("Fk_ObjetivoSocial");

		/*builder.HasOne(d => d.ObjetivoSocial)
			.WithMany(p => p.TuteladosObjetivos)
			.HasForeignKey(d => d.ObjetivoSocialId);*/

		/*builder.HasOne(d => d.TipoObjetivo)
			.WithMany(p => p.TuteladosObjetivos)
			.HasForeignKey(d => d.TipoObjetivoId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Objetivos)
			.HasForeignKey(d => d.TuteladoId);

		builder.Navigation(to => to.ObjetivoSocial).AutoInclude();

	}
}
