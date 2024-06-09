using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class NivelSoporteConfiguration : IEntityTypeConfiguration<NivelSoporte>
	{
		public void Configure(EntityTypeBuilder<NivelSoporte> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_NivelSoporte");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}