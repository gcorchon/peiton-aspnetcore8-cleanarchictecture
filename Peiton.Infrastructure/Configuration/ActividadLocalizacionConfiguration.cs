using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ActividadLocalizacionConfiguration : IEntityTypeConfiguration<ActividadLocalizacion>
	{
		public void Configure(EntityTypeBuilder<ActividadLocalizacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_ActividadLocalizacion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}