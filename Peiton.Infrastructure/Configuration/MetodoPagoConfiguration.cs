using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MetodoPagoConfiguration : IEntityTypeConfiguration<MetodoPago>
{
	public void Configure(EntityTypeBuilder<MetodoPago> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MetodoPago");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
