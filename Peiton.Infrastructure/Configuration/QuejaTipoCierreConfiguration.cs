using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class QuejaTipoCierreConfiguration : IEntityTypeConfiguration<QuejaTipoCierre>
{
	public void Configure(EntityTypeBuilder<QuejaTipoCierre> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_QuejaTipoCierre");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
