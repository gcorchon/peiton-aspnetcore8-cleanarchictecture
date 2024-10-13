using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoFinanciacionPublicaConfiguration : IEntityTypeConfiguration<TipoFinanciacionPublica>
{
	public void Configure(EntityTypeBuilder<TipoFinanciacionPublica> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoFinanciacionPublica");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
