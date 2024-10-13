using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AllegadoConfiguration : IEntityTypeConfiguration<Allegado>
{
	public void Configure(EntityTypeBuilder<Allegado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Allegado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
