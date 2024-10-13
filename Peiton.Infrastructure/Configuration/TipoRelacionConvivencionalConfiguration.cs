using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoRelacionConvivencionalConfiguration : IEntityTypeConfiguration<TipoRelacionConvivencional>
{
	public void Configure(EntityTypeBuilder<TipoRelacionConvivencional> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoRelacionConvivencional");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
