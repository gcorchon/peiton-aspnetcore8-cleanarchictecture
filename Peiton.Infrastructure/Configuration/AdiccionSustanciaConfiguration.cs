using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AdiccionSustanciaConfiguration : IEntityTypeConfiguration<AdiccionSustancia>
	{
		public void Configure(EntityTypeBuilder<AdiccionSustancia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AdiccionSustancia");
			builder.Property(p => p.Descripcion).HasMaxLength(150);

		}
	}
}