using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class VoluntariadoTipoConfiguration : IEntityTypeConfiguration<VoluntariadoTipo>
{
	public void Configure(EntityTypeBuilder<VoluntariadoTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_VoluntariadoTipo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
