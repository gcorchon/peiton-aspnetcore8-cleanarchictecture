using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class JuzgadoConfiguration : IEntityTypeConfiguration<Juzgado>
{
	public void Configure(EntityTypeBuilder<Juzgado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Juzgado");
		builder.Property(p => p.Descripcion).HasMaxLength(255);

	}
}
