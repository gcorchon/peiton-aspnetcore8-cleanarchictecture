using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoAvisoTributarioConfiguration : IEntityTypeConfiguration<TipoAvisoTributario>
	{
		public void Configure(EntityTypeBuilder<TipoAvisoTributario> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TipoAvisoTributario");
			builder.Property(p => p.Descripcion).HasMaxLength(50);
			builder.Property(p => p.Inmueble).IsRequired();
			builder.Property(p => p.IRPF).IsRequired();

		}
	}
}