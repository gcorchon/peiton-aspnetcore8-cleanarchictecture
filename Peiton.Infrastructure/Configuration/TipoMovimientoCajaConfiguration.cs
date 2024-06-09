using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoMovimientoCajaConfiguration : IEntityTypeConfiguration<TipoMovimientoCaja>
	{
		public void Configure(EntityTypeBuilder<TipoMovimientoCaja> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoMovimientoCaja");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}