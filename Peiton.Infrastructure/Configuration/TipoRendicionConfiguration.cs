using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoRendicionConfiguration : IEntityTypeConfiguration<TipoRendicion>
	{
		public void Configure(EntityTypeBuilder<TipoRendicion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoRendicion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}