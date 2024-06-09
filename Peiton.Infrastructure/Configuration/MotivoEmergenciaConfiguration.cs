using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class MotivoEmergenciaConfiguration : IEntityTypeConfiguration<MotivoEmergencia>
	{
		public void Configure(EntityTypeBuilder<MotivoEmergencia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MotivoEmergencia");
			builder.Property(p => p.Descripcion).HasMaxLength(255);

		}
	}
}