using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AmbitoCoberturaServicioConfiguration : IEntityTypeConfiguration<AmbitoCoberturaServicio>
	{
		public void Configure(EntityTypeBuilder<AmbitoCoberturaServicio> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AmbitoCoberturaServicio");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}