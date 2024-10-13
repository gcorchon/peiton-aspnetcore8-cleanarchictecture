using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoLaboralFormativaConfiguration : IEntityTypeConfiguration<TipoLaboralFormativa>
{
	public void Configure(EntityTypeBuilder<TipoLaboralFormativa> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoLaboralFormativa");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
