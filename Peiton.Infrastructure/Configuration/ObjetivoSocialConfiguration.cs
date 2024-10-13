using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ObjetivoSocialConfiguration : IEntityTypeConfiguration<ObjetivoSocial>
{
	public void Configure(EntityTypeBuilder<ObjetivoSocial> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ObjetivoSocial");
		builder.Property(p => p.Descripcion).HasMaxLength(255);
		builder.Property(p => p.TipoObjetivoId).HasColumnName("Fk_TipoObjetivo");

		/*builder.HasOne(d => d.TipoObjetivo)
			.WithMany(p => p.ObjetivosSociales)
			.HasForeignKey(d => d.TipoObjetivoId);*/

	}
}
