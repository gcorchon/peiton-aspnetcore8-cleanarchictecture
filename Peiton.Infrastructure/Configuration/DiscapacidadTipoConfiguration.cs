using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DiscapacidadTipoConfiguration : IEntityTypeConfiguration<DiscapacidadTipo>
	{
		public void Configure(EntityTypeBuilder<DiscapacidadTipo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_DiscapacidadTipo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}