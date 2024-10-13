using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MedidaPenalNaturalezaConfiguration : IEntityTypeConfiguration<MedidaPenalNaturaleza>
{
	public void Configure(EntityTypeBuilder<MedidaPenalNaturaleza> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MedidaPenalNaturaleza");
		builder.Property(p => p.Descripcion).HasMaxLength(100);
		builder.Property(p => p.MedidaPenalTipoId).HasColumnName("Fk_MedidaPenalTipo");

		/*builder.HasOne(d => d.MedidaPenalTipo)
			.WithMany(p => p.MedidasPenalesNaturalezas)
			.HasForeignKey(d => d.MedidaPenalTipoId);*/

	}
}
