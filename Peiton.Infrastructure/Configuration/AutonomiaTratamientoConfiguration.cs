using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AutonomiaTratamientoConfiguration : IEntityTypeConfiguration<AutonomiaTratamiento>
{
	public void Configure(EntityTypeBuilder<AutonomiaTratamiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AutonomiaTratamiento");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
