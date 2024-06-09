using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoServicioApoyoFormalConfiguration : IEntityTypeConfiguration<TipoServicioApoyoFormal>
	{
		public void Configure(EntityTypeBuilder<TipoServicioApoyoFormal> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoServicioApoyoFormal");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}