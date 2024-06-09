using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoPagoConfiguration : IEntityTypeConfiguration<TipoPago>
	{
		public void Configure(EntityTypeBuilder<TipoPago> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoPago");
			builder.Property(p => p.Descripcion).HasMaxLength(10);

		}
	}
}