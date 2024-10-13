using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SucesionTipoConfiguration : IEntityTypeConfiguration<SucesionTipo>
{
	public void Configure(EntityTypeBuilder<SucesionTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SucesionTipo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
