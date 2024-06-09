using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PeriodicidadConfiguration : IEntityTypeConfiguration<Periodicidad>
	{
		public void Configure(EntityTypeBuilder<Periodicidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Periodicidad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Unidad).HasMaxLength(0);

		}
	}
}