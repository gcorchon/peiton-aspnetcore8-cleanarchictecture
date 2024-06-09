using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoInmuebleConfiguration : IEntityTypeConfiguration<TipoInmueble>
	{
		public void Configure(EntityTypeBuilder<TipoInmueble> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoInmueble");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}