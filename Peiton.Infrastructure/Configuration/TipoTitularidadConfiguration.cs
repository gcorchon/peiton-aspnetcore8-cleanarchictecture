using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoTitularidadConfiguration : IEntityTypeConfiguration<TipoTitularidad>
	{
		public void Configure(EntityTypeBuilder<TipoTitularidad> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoTitularidad");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}