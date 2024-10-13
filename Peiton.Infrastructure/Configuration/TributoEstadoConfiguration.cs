using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TributoEstadoConfiguration : IEntityTypeConfiguration<TributoEstado>
{
	public void Configure(EntityTypeBuilder<TributoEstado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TributoEstado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
