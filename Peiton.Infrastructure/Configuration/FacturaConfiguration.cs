using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
	public void Configure(EntityTypeBuilder<Factura> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Factura");
		builder.Property(p => p.NumRegAMTA).HasMaxLength(50);
		builder.Property(p => p.CodFactura).HasMaxLength(50);
		builder.Property(p => p.NIFExpedidor).HasMaxLength(50);
		builder.Property(p => p.Denominacion).HasMaxLength(255);
		builder.Property(p => p.NumeroFactura).HasMaxLength(50);
		builder.Property(p => p.CodDirAMTA).HasMaxLength(50);
		builder.Property(p => p.NumeroMovimiento).HasMaxLength(50);
		builder.Property(p => p.AsientoId).HasColumnName("Fk_Asiento");
		builder.Property(p => p.Domiciliado).IsRequired();
		builder.Property(p => p.FACe).IsRequired();
		builder.Property(p => p.Ejercicio).HasMaxLength(50);
		builder.Property(p => p.NumeroRegistroFACe).HasMaxLength(255);
		builder.Property(p => p.Importe).HasColumnType("money");
		builder.HasOne(d => d.Asiento)
			.WithMany(p => p.Facturas)
			.HasForeignKey(d => d.AsientoId);

	}
}
