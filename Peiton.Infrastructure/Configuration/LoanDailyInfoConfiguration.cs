using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class LoanDailyInfoConfiguration : IEntityTypeConfiguration<LoanDailyInfo>
{
	public void Configure(EntityTypeBuilder<LoanDailyInfo> builder)
	{
		builder.HasKey(t => new { t.LoanId, t.Fecha });

		builder.Property(p => p.LoanId).HasColumnName("Fk_Loan");
		builder.Property(p => p.AccountNumber).HasMaxLength(50);
		builder.Property(p => p.AccountType).HasMaxLength(50);
		builder.Property(p => p.AliasEnabled).HasMaxLength(50);
		builder.Property(p => p.Bank).HasMaxLength(50);
		builder.Property(p => p.Branch).HasMaxLength(50);
		builder.Property(p => p.ControlDigits).HasMaxLength(50);
		builder.Property(p => p.Currency).HasMaxLength(50);
		builder.Property(p => p.Deduction).HasMaxLength(50);
		builder.Property(p => p.DifferentialRate).HasMaxLength(50);
		builder.Property(p => p.PartialDeprecRate).HasMaxLength(50);
		builder.Property(p => p.ReferentialKey).HasMaxLength(50);
		builder.Property(p => p.Secuential).HasMaxLength(50);
		builder.Property(p => p.TotalDeprecRate).HasMaxLength(50);
		builder.Property(p => p.ValueRate).HasMaxLength(50);
		builder.Property(p => p.WebAlias).HasMaxLength(255);
		builder.Property(p => p.InitialBalance).HasColumnType("money");
		builder.Property(p => p.Debt).HasColumnType("money");
		/*builder.HasOne(d => d.Loan)
			.WithMany(p => p.LoanesDailyInfos)
			.HasForeignKey(d => d.LoanId);*/

	}
}
