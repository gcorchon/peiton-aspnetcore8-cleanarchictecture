using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FondoSolidarioPeriodicidadConfiguration : IEntityTypeConfiguration<FondoSolidarioPeriodicidad>
{
	public void Configure(EntityTypeBuilder<FondoSolidarioPeriodicidad> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidarioPeriodicidad");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
