using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ValoracionProfesionalConfiguration : IEntityTypeConfiguration<ValoracionProfesional>
{
	public void Configure(EntityTypeBuilder<ValoracionProfesional> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ValoracionProfesional");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

	}
}
