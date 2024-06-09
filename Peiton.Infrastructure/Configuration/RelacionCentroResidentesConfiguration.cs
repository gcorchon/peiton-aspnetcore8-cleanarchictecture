using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class RelacionCentroResidentesConfiguration : IEntityTypeConfiguration<RelacionCentroResidentes>
	{
		public void Configure(EntityTypeBuilder<RelacionCentroResidentes> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_RelacionCentroResidentes");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}