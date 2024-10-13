using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AsientoConfiguration : IEntityTypeConfiguration<Asiento>
{
	public void Configure(EntityTypeBuilder<Asiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Asiento");
		builder.Property(p => p.AccountTransactionCPId).HasColumnName("Fk_AccountTransactionCP");
		builder.Property(p => p.CajaAMTAId).HasColumnName("Fk_CajaAMTA");
		builder.Property(p => p.PartidaId).HasColumnName("Fk_Partida");
		builder.Property(p => p.Concepto).HasMaxLength(255);
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.ClienteId).HasColumnName("Fk_Cliente");
		builder.Property(p => p.FormaPagoId).HasColumnName("Fk_FormaPago");
		builder.Property(p => p.Importe).HasColumnType("money");

		builder.HasOne(d => d.AccountTransactionCP)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.AccountTransactionCPId);

		/*builder.HasOne(d => d.FormaPago)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.FormaPagoId);*/

		builder.HasOne(d => d.CajaAMTA)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.CajaAMTAId);

		builder.HasOne(d => d.Cliente)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.ClienteId);

		/*builder.HasOne(d => d.Partida)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.PartidaId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Asientos)
			.HasForeignKey(d => d.TuteladoId);

	}
}
