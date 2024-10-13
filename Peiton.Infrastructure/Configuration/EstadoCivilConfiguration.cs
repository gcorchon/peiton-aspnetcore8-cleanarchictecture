using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EstadoCivilConfiguration : IEntityTypeConfiguration<EstadoCivil>
{
	public void Configure(EntityTypeBuilder<EstadoCivil> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EstadoCivil");
		builder.Property(p => p.Descripcion).HasMaxLength(20);
		builder.Property(p => p.DescripcionFemenino).HasMaxLength(20);

	}
}
