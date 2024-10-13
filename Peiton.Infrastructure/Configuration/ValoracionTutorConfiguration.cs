using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ValoracionTutorConfiguration : IEntityTypeConfiguration<ValoracionTutor>
{
	public void Configure(EntityTypeBuilder<ValoracionTutor> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ValoracionTutor");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

	}
}
