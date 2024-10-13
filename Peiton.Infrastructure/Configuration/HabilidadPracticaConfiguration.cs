using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class HabilidadPracticaConfiguration : IEntityTypeConfiguration<HabilidadPractica>
{
	public void Configure(EntityTypeBuilder<HabilidadPractica> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_HabilidadPractica");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
