using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EstadoAprobacionCGJConfiguration : IEntityTypeConfiguration<EstadoAprobacionCGJ>
	{
		public void Configure(EntityTypeBuilder<EstadoAprobacionCGJ> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EstadoAprobacionCGJ");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}