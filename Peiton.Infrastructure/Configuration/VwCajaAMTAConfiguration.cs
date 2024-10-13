using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class VwCajaAMTAConfiguration : IEntityTypeConfiguration<VwCajaAMTA>
{
	public void Configure(EntityTypeBuilder<VwCajaAMTA> builder)
	{
		builder.HasKey(t => t.Id);

		builder.ToView("vwCajaAMTA");
		builder.Property(v => v.Id).HasColumnName("Pk_CajaAMTA");
		builder.Property(v => v.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(v => v.CajaId).HasColumnName("Fk_Caja");

		builder.HasOne(d => d.Caja)
			.WithMany(p => p.VwCajaAMTA)
			.HasForeignKey(d => d.CajaId);

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.VwCajaAMTA)
			.HasForeignKey(d => d.TuteladoId);

	}
}
