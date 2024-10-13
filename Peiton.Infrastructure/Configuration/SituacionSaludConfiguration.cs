using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SituacionSaludConfiguration : IEntityTypeConfiguration<SituacionSalud>
{
	public void Configure(EntityTypeBuilder<SituacionSalud> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SituacionSalud");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
