using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoResidenciaConfiguration : IEntityTypeConfiguration<TipoResidencia>
	{
		public void Configure(EntityTypeBuilder<TipoResidencia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoResidencia");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}