using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DeudaConfiguration : IEntityTypeConfiguration<Deuda>
{
	public void Configure(EntityTypeBuilder<Deuda> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Deuda");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Concepto).HasMaxLength(150);
		builder.Property(p => p.Importe).HasColumnType("money");
		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Deudas)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
