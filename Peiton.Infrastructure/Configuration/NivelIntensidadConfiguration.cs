using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class NivelIntensidadConfiguration : IEntityTypeConfiguration<NivelIntensidad>
	{
		public void Configure(EntityTypeBuilder<NivelIntensidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_NivelIntensidad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}