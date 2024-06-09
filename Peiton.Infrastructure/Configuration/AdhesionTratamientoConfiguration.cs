using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AdhesionTratamientoConfiguration : IEntityTypeConfiguration<AdhesionTratamiento>
	{
		public void Configure(EntityTypeBuilder<AdhesionTratamiento> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AdhesionTratamiento");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}