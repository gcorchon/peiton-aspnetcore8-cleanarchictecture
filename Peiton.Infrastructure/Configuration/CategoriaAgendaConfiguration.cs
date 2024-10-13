using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CategoriaAgendaConfiguration : IEntityTypeConfiguration<CategoriaAgenda>
{
	public void Configure(EntityTypeBuilder<CategoriaAgenda> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_CategoriaAgenda");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
