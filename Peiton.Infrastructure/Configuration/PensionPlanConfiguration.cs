using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class PensionPlanConfiguration : IEntityTypeConfiguration<PensionPlan>
{
	public void Configure(EntityTypeBuilder<PensionPlan> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_PensionPlan");
		builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
		builder.Property(p => p.PlanNumber).HasMaxLength(255);
		builder.Property(p => p.WebAlias).HasMaxLength(255);
		builder.Property(p => p.Currency).HasMaxLength(255);
		builder.Property(p => p.StartDate).HasDefaultValueSql("(CONVERT([date],getdate(),0))");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Titularidad).HasMaxLength(10);
		builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
		builder.Property(p => p.Saldo).HasColumnType("money");
		/*builder.HasOne(d => d.Credencial)
			.WithMany(p => p.PensionesPlanes)
			.HasForeignKey(d => d.CredencialId);*/

	}
}
