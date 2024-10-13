using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TareaTipoConfiguration : IEntityTypeConfiguration<TareaTipo>
{
	public void Configure(EntityTypeBuilder<TareaTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TareaTipo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
