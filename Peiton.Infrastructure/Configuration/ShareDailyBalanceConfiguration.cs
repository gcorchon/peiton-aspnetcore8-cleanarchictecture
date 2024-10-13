using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ShareDailyBalanceConfiguration : IEntityTypeConfiguration<ShareDailyBalance>
{
	public void Configure(EntityTypeBuilder<ShareDailyBalance> builder)
	{
		builder.HasKey(t => new { t.ShareId, t.Fecha });

		builder.Property(p => p.ShareId).HasColumnName("Fk_Share");

		builder.Property(p => p.Balance).HasColumnType("money");
		/*builder.HasOne(d => d.Share)
			.WithMany(p => p.SharesDailyBalances)
			.HasForeignKey(d => d.ShareId);*/

	}
}
