using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TareaDepartamentoConfiguration : IEntityTypeConfiguration<TareaDepartamento>
{
	public void Configure(EntityTypeBuilder<TareaDepartamento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TareaDepartamento");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
