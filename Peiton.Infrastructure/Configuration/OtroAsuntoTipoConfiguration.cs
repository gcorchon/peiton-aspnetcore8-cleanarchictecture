using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class OtroAsuntoTipoConfiguration : IEntityTypeConfiguration<OtroAsuntoTipo>
{
	public void Configure(EntityTypeBuilder<OtroAsuntoTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_OtroAsuntoTipo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
