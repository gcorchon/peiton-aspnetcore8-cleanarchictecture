using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GradoApoyoConfiguration : IEntityTypeConfiguration<GradoApoyo>
{
	public void Configure(EntityTypeBuilder<GradoApoyo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_GradoApoyo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
