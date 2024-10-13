using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DepositDailyBalanceConfiguration : IEntityTypeConfiguration<DepositDailyBalance>
{
	public void Configure(EntityTypeBuilder<DepositDailyBalance> builder)
	{
		builder.HasKey(t => new { t.DepositId, t.Fecha });

		builder.Property(p => p.DepositId).HasColumnName("Fk_Deposit");
		builder.Property(p => p.Balance).HasColumnType("money");
		/*builder.HasOne(d => d.Deposit)
			.WithMany(p => p.DepositDailyBalances)
			.HasForeignKey(d => d.DepositId);*/

	}
}
