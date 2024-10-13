using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AdaptacionCentroConfiguration : IEntityTypeConfiguration<AdaptacionCentro>
{
	public void Configure(EntityTypeBuilder<AdaptacionCentro> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_AdaptacionCentro");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
