using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RazonDenegacionCGJConfiguration : IEntityTypeConfiguration<RazonDenegacionCGJ>
	{
		public void Configure(EntityTypeBuilder<RazonDenegacionCGJ> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_RazonDenegacionCGJ");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}