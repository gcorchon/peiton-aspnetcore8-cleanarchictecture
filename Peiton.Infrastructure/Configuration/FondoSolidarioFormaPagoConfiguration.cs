using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class FondoSolidarioFormaPagoConfiguration : IEntityTypeConfiguration<FondoSolidarioFormaPago>
	{
		public void Configure(EntityTypeBuilder<FondoSolidarioFormaPago> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidarioFormaPago");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}