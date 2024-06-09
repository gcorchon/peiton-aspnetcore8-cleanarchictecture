using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class LogCredencialConfiguration : IEntityTypeConfiguration<LogCredencial>
	{
		public void Configure(EntityTypeBuilder<LogCredencial> builder)
		{
			builder.HasKey(t => new { t.EurobitsId, t.UserId, t.Fecha});

			builder.Property(p => p.EurobitsId).HasMaxLength(50);
			builder.Property(p => p.UserId).HasMaxLength(50);
			builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
			builder.Property(p => p.Productos).HasMaxLength(250);

		}
	}
}