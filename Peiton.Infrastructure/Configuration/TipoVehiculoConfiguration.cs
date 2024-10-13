using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoVehiculoConfiguration : IEntityTypeConfiguration<TipoVehiculo>
{
	public void Configure(EntityTypeBuilder<TipoVehiculo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoVehiculo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
