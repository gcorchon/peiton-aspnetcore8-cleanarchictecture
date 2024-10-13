using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CausaNotaSimpleConfiguration : IEntityTypeConfiguration<CausaNotaSimple>
{
	public void Configure(EntityTypeBuilder<CausaNotaSimple> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_CausaNotaSimple");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
