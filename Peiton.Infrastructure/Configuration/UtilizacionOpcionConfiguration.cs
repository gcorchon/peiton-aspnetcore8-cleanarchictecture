using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class UtilizacionOpcionConfiguration : IEntityTypeConfiguration<UtilizacionOpcion>
{
	public void Configure(EntityTypeBuilder<UtilizacionOpcion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_UtilizacionOpcion");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

		/*builder.HasMany(d => d.Inmuebles)
			.WithMany(p => p.UtilizacionesOpciones)
			.UsingEntity<Dictionary<string, object>>(
		"InmuebleUtilizacionOpcion",
		l => l.HasOne<Inmueble>().WithMany().HasForeignKey("Fk_Inmueble"),
		r => r.HasOne<UtilizacionOpcion>().WithMany().HasForeignKey("Fk_UtilizacionOpcion"),
		j =>
		{
			j.HasKey("Fk_UtilizacionOpcion", "Fk_Inmueble");
			j.ToTable("InmuebleUtilizacionOpcion");
			});*/
	}
}
