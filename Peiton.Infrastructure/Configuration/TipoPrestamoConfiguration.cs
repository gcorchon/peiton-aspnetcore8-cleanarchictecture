using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoPrestamoConfiguration : IEntityTypeConfiguration<TipoPrestamo>
	{
		public void Configure(EntityTypeBuilder<TipoPrestamo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoPrestamo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}