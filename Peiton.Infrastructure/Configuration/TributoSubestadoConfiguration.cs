using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TributoSubestadoConfiguration : IEntityTypeConfiguration<TributoSubestado>
{
	public void Configure(EntityTypeBuilder<TributoSubestado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TributoSubestado");
		builder.Property(p => p.TributoEstadoId).HasColumnName("Fk_TributoEstado");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

		/*builder.HasOne(d => d.TributoEstado)
			.WithMany(p => p.TributosSubestados)
			.HasForeignKey(d => d.TributoEstadoId);*/

	}
}
