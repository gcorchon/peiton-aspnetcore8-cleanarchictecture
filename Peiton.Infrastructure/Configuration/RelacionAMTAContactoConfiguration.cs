using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class RelacionAMTAContactoConfiguration : IEntityTypeConfiguration<RelacionAMTAContacto>
{
	public void Configure(EntityTypeBuilder<RelacionAMTAContacto> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_RelacionAMTAContacto");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

	}
}
