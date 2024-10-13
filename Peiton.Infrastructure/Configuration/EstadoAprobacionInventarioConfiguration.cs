using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EstadoAprobacionInventarioConfiguration : IEntityTypeConfiguration<EstadoAprobacionInventario>
{
	public void Configure(EntityTypeBuilder<EstadoAprobacionInventario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EstadoAprobacionInventario");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
