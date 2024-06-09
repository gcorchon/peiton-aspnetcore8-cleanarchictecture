using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PensionPlanDailyInfoConfiguration : IEntityTypeConfiguration<PensionPlanDailyInfo>
	{
		public void Configure(EntityTypeBuilder<PensionPlanDailyInfo> builder)
		{
			builder.HasKey(t => new { t.PensionPlanId, t.Fecha});

			builder.Property(p => p.PensionPlanId).HasColumnName("Fk_PensionPlan");
			builder.Property(p => p.Balance).HasColumnType("money");
			/*builder.HasOne(d => d.PensionPlan)
				.WithMany(p => p.PensionesPlanesDailyInfos)
				.HasForeignKey(d => d.PensionPlanId);*/

		}
	}
}