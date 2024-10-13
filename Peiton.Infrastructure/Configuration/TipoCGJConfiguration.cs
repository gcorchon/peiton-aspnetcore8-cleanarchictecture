using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoCGJConfiguration : IEntityTypeConfiguration<TipoCGJ>
{
	public void Configure(EntityTypeBuilder<TipoCGJ> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoCGJ");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
