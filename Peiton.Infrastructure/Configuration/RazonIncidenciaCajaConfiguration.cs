using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RazonIncidenciaCajaConfiguration : IEntityTypeConfiguration<RazonIncidenciaCaja>
{
	public void Configure(EntityTypeBuilder<RazonIncidenciaCaja> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_RazonIncidenciaCaja");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
