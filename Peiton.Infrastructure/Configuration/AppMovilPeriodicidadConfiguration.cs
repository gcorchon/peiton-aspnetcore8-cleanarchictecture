using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AppMovilPeriodicidadConfiguration : IEntityTypeConfiguration<AppMovilPeriodicidad>
	{
		public void Configure(EntityTypeBuilder<AppMovilPeriodicidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_AppMovilPeriodicidad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}