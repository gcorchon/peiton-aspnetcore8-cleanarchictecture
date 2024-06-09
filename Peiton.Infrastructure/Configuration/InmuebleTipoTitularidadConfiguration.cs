using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleTipoTitularidadConfiguration : IEntityTypeConfiguration<InmuebleTipoTitularidad>
	{
		public void Configure(EntityTypeBuilder<InmuebleTipoTitularidad> builder)
		{
			builder.HasKey(t => new { t.InmuebleId, t.Orden});

			builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
			builder.Property(p => p.TipoTitularidadId).HasColumnName("Fk_TipoTitularidad");
			builder.Property(p => p.Porcentaje).HasMaxLength(10);

			/*builder.HasOne(d => d.Inmueble)
				.WithMany(p => p.InmueblesTiposTitularidades)
				.HasForeignKey(d => d.InmuebleId);*/

			/*builder.HasOne(d => d.TipoTitularidad)
				.WithMany(p => p.InmueblesTiposTitularidades)
				.HasForeignKey(d => d.TipoTitularidadId);*/

		}
	}
}