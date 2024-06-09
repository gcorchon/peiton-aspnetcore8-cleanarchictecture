using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AccountDailyBalanceRealConfiguration : IEntityTypeConfiguration<AccountDailyBalanceReal>
	{
		public void Configure(EntityTypeBuilder<AccountDailyBalanceReal> builder)
		{
			builder.HasKey(t => new { t.AccountId, t.Fecha});

			builder.Property(p => p.AccountId).HasColumnName("Fk_Account");
			builder.Property(p => p.Balance).HasColumnType("money");
			/*builder.HasOne(d => d.Account)
				.WithMany(p => p.AccountsDailyBalancesReales)
				.HasForeignKey(d => d.AccountId);*/

		}
	}
}