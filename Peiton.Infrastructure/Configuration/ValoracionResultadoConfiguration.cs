using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ValoracionResultadoConfiguration : IEntityTypeConfiguration<ValoracionResultado>
	{
		public void Configure(EntityTypeBuilder<ValoracionResultado> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ValoracionResultado");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}