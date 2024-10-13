using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EstadoRetribucionConfiguration : IEntityTypeConfiguration<EstadoRetribucion>
{
	public void Configure(EntityTypeBuilder<EstadoRetribucion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EstadoRetribucion");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
