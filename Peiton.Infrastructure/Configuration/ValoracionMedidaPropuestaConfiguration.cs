using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ValoracionMedidaPropuestaConfiguration : IEntityTypeConfiguration<ValoracionMedidaPropuesta>
	{
		public void Configure(EntityTypeBuilder<ValoracionMedidaPropuesta> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ValoracionMedidaPropuesta");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}