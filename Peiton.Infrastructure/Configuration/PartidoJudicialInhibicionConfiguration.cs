using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PartidoJudicialInhibicionConfiguration : IEntityTypeConfiguration<PartidoJudicialInhibicion>
{
	public void Configure(EntityTypeBuilder<PartidoJudicialInhibicion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_PartidoJudicialInhibicion");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
