using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SeguroAhorroConfiguration : IEntityTypeConfiguration<SeguroAhorro>
{
	public void Configure(EntityTypeBuilder<SeguroAhorro> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SeguroAhorro");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.SeguroId).HasColumnName("Fk_Seguro");
		builder.Property(p => p.NumeroPoliza).HasMaxLength(50);
		builder.Property(p => p.PrimaUnica).HasColumnType("money");
		/*builder.HasOne(d => d.Seguro)
			.WithMany(p => p.SegurosAhorros)
			.HasForeignKey(d => d.SeguroId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.SegurosAhorros)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
