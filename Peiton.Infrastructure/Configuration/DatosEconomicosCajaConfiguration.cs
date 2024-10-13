using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DatosEconomicosCajaConfiguration : IEntityTypeConfiguration<DatosEconomicosCaja>
{
	public void Configure(EntityTypeBuilder<DatosEconomicosCaja> builder)
	{
		builder.HasKey(t => t.TuteladoId);

		builder.Property(p => p.TuteladoId).ValueGeneratedNever().HasColumnName("Fk_Tutelado");
		builder.Property(p => p.LocalizacionCajaId).HasColumnName("Fk_LocalizacionCaja");

		builder.HasOne(d => d.Tutelado)
			.WithOne(p => p.DatosEconomicosCaja)
			.HasForeignKey<DatosEconomicosCaja>(t => t.TuteladoId);

		/*builder.HasOne(d => d.LocalizacionCaja)
			.WithMany(p => p.DatosEconomicosCaja)
			.HasForeignKey(d => d.LocalizacionCajaId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.DatosEconomicosCaja)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
