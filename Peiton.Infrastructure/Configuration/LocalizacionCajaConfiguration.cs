using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class LocalizacionCajaConfiguration : IEntityTypeConfiguration<LocalizacionCaja>
	{
		public void Configure(EntityTypeBuilder<LocalizacionCaja> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_LocalizacionCaja");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}