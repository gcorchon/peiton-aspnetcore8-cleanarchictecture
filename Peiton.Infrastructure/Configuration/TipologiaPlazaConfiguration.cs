using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipologiaPlazaConfiguration : IEntityTypeConfiguration<TipologiaPlaza>
{
	public void Configure(EntityTypeBuilder<TipologiaPlaza> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipologiaPlaza");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
