using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DependenciaConfiguration : IEntityTypeConfiguration<Dependencia>
{
	public void Configure(EntityTypeBuilder<Dependencia> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Dependencia");
		builder.Property(p => p.Descripcion).HasMaxLength(20);

	}
}
