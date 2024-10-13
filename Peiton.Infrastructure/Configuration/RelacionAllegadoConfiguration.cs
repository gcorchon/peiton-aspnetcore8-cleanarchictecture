using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RelacionAllegadoConfiguration : IEntityTypeConfiguration<RelacionAllegado>
{
	public void Configure(EntityTypeBuilder<RelacionAllegado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_RelacionAllegado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
