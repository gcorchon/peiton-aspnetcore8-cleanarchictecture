using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoOrientacionConfiguration : IEntityTypeConfiguration<TipoOrientacion>
{
	public void Configure(EntityTypeBuilder<TipoOrientacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoOrientacion");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
