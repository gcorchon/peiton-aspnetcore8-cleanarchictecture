using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class UrgenciaConceptoCosteConfiguration : IEntityTypeConfiguration<UrgenciaConceptoCoste>
{
	public void Configure(EntityTypeBuilder<UrgenciaConceptoCoste> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_UrgenciaConceptoCoste");
		builder.Property(p => p.Descripcion).HasMaxLength(255);

	}
}
