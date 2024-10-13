using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CNAEConfiguration : IEntityTypeConfiguration<CNAE>
{
	public void Configure(EntityTypeBuilder<CNAE> builder)
	{
		builder.HasKey(t => t.Cnae2009);

		builder.Property(p => p.Cnae2009).ValueGeneratedNever().HasMaxLength(2);
		builder.Property(p => p.Description).HasMaxLength(255);
		builder.Property(p => p.CategoriaId).HasColumnName("Fk_Categoria");


	}
}
