using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EmergenciaLlamadaConfiguration : IEntityTypeConfiguration<EmergenciaLlamada>
	{
		public void Configure(EntityTypeBuilder<EmergenciaLlamada> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EmergenciaLLamada");
			builder.Property(p => p.Descripcion).HasMaxLength(250);

		}
	}
}