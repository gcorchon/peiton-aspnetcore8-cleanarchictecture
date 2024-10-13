using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MedidaPenalMedidaConfiguration : IEntityTypeConfiguration<MedidaPenalMedida>
{
	public void Configure(EntityTypeBuilder<MedidaPenalMedida> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MedidaPenalMedida");
		builder.Property(p => p.Descripcion).HasMaxLength(100);
		builder.Property(p => p.MedidaPenalNaturalezaId).HasColumnName("Fk_MedidaPenalNaturaleza");

		/*builder.HasOne(d => d.MedidaPenalNaturaleza)
			.WithMany(p => p.MedidasPenalesMedidas)
			.HasForeignKey(d => d.MedidaPenalNaturalezaId);*/

	}
}
