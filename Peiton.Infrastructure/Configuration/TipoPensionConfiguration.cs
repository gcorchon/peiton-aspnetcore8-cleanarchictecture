using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoPensionConfiguration : IEntityTypeConfiguration<TipoPension>
{
	public void Configure(EntityTypeBuilder<TipoPension> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoPension");
		builder.Property(p => p.Descripcion).HasMaxLength(255);

	}
}
