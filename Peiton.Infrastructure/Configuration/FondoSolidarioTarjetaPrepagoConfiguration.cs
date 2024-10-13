using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FondoSolidarioTarjetaPrepagoConfiguration : IEntityTypeConfiguration<FondoSolidarioTarjetaPrepago>
{
	public void Configure(EntityTypeBuilder<FondoSolidarioTarjetaPrepago> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidarioTarjetaPrepago");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
