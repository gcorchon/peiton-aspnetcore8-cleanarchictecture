using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoFinanciacionConfiguration : IEntityTypeConfiguration<TipoFinanciacion>
{
	public void Configure(EntityTypeBuilder<TipoFinanciacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoFinanciacion");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
