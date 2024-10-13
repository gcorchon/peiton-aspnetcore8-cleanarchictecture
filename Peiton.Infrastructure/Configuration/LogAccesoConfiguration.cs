using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class LogAccesoConfiguration : IEntityTypeConfiguration<LogAcceso>
{
	public void Configure(EntityTypeBuilder<LogAcceso> builder)
	{
		builder.HasKey(t => new { t.Usuario, t.Fecha });

		builder.Property(p => p.Usuario).HasMaxLength(50);
		builder.Property(p => p.Fecha).HasDefaultValueSql("(getdate())");
		builder.Property(p => p.IP).HasMaxLength(127);

	}
}
