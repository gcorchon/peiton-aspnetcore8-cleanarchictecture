using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FundDailyInfoConfiguration : IEntityTypeConfiguration<FundDailyInfo>
{
	public void Configure(EntityTypeBuilder<FundDailyInfo> builder)
	{
		builder.HasKey(t => new { t.FundId, t.ValueDate });

		builder.Property(p => p.FundId).HasColumnName("Fk_Fund");
		builder.Property(p => p.Balance).HasColumnType("money");
		/*builder.HasOne(d => d.Fund)
			.WithMany(p => p.FundesDailyInfos)
			.HasForeignKey(d => d.FundId);*/

	}
}
