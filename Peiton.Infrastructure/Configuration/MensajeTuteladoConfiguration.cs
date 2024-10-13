using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MensajeTuteladoConfiguration : IEntityTypeConfiguration<MensajeTutelado>
{
	public void Configure(EntityTypeBuilder<MensajeTutelado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_MensajeTutelado");
		builder.Property(p => p.Asunto).HasMaxLength(255);
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

	}
}
