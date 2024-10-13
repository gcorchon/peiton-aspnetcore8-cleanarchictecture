using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EstadoAprobacionRendicionConfiguration : IEntityTypeConfiguration<EstadoAprobacionRendicion>
{
	public void Configure(EntityTypeBuilder<EstadoAprobacionRendicion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EstadoAprobacionRendicion");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
