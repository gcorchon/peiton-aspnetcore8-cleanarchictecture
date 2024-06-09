using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoAprobacionRendicionConfiguration : IEntityTypeConfiguration<TipoAprobacionRendicion>
	{
		public void Configure(EntityTypeBuilder<TipoAprobacionRendicion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoAprobacionRendicion");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}