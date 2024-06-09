using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TributoPeriodicidadConfiguration : IEntityTypeConfiguration<TributoPeriodicidad>
	{
		public void Configure(EntityTypeBuilder<TributoPeriodicidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TributoPeriodicidad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Etiqueta).HasMaxLength(50);

		}
	}
}