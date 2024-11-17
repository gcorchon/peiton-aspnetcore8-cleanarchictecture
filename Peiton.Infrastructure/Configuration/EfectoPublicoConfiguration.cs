using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EfectoPublicoConfiguration : IEntityTypeConfiguration<EfectoPublico>
{
	public void Configure(EntityTypeBuilder<EfectoPublico> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_EfectoPublico");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.TipoProducto).HasMaxLength(50);
		builder.Property(p => p.Identificacion).HasMaxLength(50);
		builder.Property(p => p.Valoracion).HasColumnType("money");

		builder.Navigation(p => p.EntidadFinanciera).AutoInclude();
		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.EfectosPublicos)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.EfectosPublicos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
