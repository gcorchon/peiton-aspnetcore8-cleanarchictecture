using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class FondoSolidarioTipoFondoConfiguration : IEntityTypeConfiguration<FondoSolidarioTipoFondo>
	{
		public void Configure(EntityTypeBuilder<FondoSolidarioTipoFondo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_FondoSolidarioTipoFondo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}