using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ValoracionMedidaCautelarConfiguration : IEntityTypeConfiguration<ValoracionMedidaCautelar>
{
	public void Configure(EntityTypeBuilder<ValoracionMedidaCautelar> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ValoracionMedidaCautelar");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

	}
}
