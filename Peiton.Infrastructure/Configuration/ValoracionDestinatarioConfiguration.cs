using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ValoracionDestinatarioConfiguration : IEntityTypeConfiguration<ValoracionDestinatario>
{
	public void Configure(EntityTypeBuilder<ValoracionDestinatario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ValoracionDestinatario");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
