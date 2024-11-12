using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SeguroContratadoConfiguration : IEntityTypeConfiguration<SeguroContratado>
{
	public void Configure(EntityTypeBuilder<SeguroContratado> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoSeguroId).HasColumnName("Fk_TipoSeguro");
		builder.Property(p => p.SeguroId).HasColumnName("Fk_Seguro");
		builder.Property(p => p.NumeroPoliza).HasMaxLength(100);
		builder.Property(p => p.Baja).IsRequired();
		builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");

		/*builder.HasOne(d => d.Inmueble)
			.WithMany(p => p.SegurosContratados)
			.HasForeignKey(d => d.InmuebleId);*/

		/*builder.HasOne(d => d.Seguro)
			.WithMany(p => p.SegurosContratados)
			.HasForeignKey(d => d.SeguroId);*/

		/*builder.HasOne(d => d.TipoSeguro)
			.WithMany(p => p.SegurosContratados)
			.HasForeignKey(d => d.TipoSeguroId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.SegurosContratados)
			.HasForeignKey(d => d.TuteladoId);

		builder.Navigation(s => s.Inmueble).AutoInclude();

	}
}
