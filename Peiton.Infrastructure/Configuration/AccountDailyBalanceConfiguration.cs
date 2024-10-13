using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AccountDailyBalanceConfiguration : IEntityTypeConfiguration<AccountDailyBalance>
{
	public void Configure(EntityTypeBuilder<AccountDailyBalance> builder)
	{
		builder.HasKey(t => new { t.AccountId, t.Fecha });

		builder.Property(p => p.AccountId).HasColumnName("Fk_Account");
		builder.Property(p => p.Balance).HasColumnType("money");
		/*builder.HasOne(d => d.Account)
			.WithMany(p => p.AccountsDailyBalances)
			.HasForeignKey(d => d.AccountId);*/

	}
}
