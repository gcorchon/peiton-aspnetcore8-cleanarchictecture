using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SueldoPensionConfiguration : IEntityTypeConfiguration<SueldoPension>
{
	public void Configure(EntityTypeBuilder<SueldoPension> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_SueldoPension");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.TipoPensionId).HasColumnName("Fk_TipoPension");
		builder.Property(p => p.Importe).HasColumnType("money");

		builder.Navigation(p => p.TipoPension).AutoInclude();
		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.SueldosPensiones)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
