using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleAnejoConfiguration : IEntityTypeConfiguration<InmuebleAnejo>
{
	public void Configure(EntityTypeBuilder<InmuebleAnejo> builder)
	{
		builder.HasKey(t => new { t.InmuebleId, t.Orden });

		builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
		builder.Property(p => p.TipoAnejoId).HasColumnName("Fk_TipoAnejo");

		/*builder.HasOne(d => d.Inmueble)
			.WithMany(p => p.InmueblesAnejos)
			.HasForeignKey(d => d.InmuebleId);*/

		/*builder.HasOne(d => d.TipoAnejo)
			.WithMany(p => p.InmueblesAnejos)
			.HasForeignKey(d => d.TipoAnejoId);*/

	}
}
