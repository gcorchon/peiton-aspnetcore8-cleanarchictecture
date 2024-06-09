using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoViaConfiguration : IEntityTypeConfiguration<TipoVia>
	{
		public void Configure(EntityTypeBuilder<TipoVia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoVia");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}