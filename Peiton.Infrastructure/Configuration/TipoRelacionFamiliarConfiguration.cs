using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoRelacionFamiliarConfiguration : IEntityTypeConfiguration<TipoRelacionFamiliar>
	{
		public void Configure(EntityTypeBuilder<TipoRelacionFamiliar> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoRelacionFamiliar");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}