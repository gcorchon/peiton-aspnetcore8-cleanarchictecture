using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CodigoEjecucionConfiguration : IEntityTypeConfiguration<CodigoEjecucion>
	{
		public void Configure(EntityTypeBuilder<CodigoEjecucion> builder)
		{
			builder.HasKey(t => new { t.Fecha, t.CredencialId});

			builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
			builder.Property(p => p.Codigo).HasMaxLength(250);

		}
	}
}