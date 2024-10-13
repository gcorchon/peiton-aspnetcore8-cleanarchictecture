using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class UrgenciaTipoEspecimenConfiguration : IEntityTypeConfiguration<UrgenciaTipoEspecimen>
{
	public void Configure(EntityTypeBuilder<UrgenciaTipoEspecimen> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_UrgenciaTipoEspecimen");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
