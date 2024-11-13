using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DiscapacidadServicioConfiguration : IEntityTypeConfiguration<DiscapacidadServicio>
{
	public void Configure(EntityTypeBuilder<DiscapacidadServicio> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_DiscapacidadServicio");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
