using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PlanDePensionConfiguration : IEntityTypeConfiguration<PlanDePension>
{
	public void Configure(EntityTypeBuilder<PlanDePension> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_PlanDePension");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.PlanNumber).HasMaxLength(255);
		builder.Property(p => p.WebAlias).HasMaxLength(255);
		builder.Property(p => p.Currency).HasMaxLength(255);
		builder.Property(p => p.StartDate).HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Titularidad).HasMaxLength(10);
		builder.Property(p => p.Saldo).HasColumnType("money");
		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.PlanesDePensiones)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.PlanesDePensiones)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
