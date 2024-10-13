using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransaction>
{
	public void Configure(EntityTypeBuilder<AccountTransaction> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AccountTransaction");
		builder.Property(p => p.AccountId).HasColumnName("Fk_Account");
		builder.Property(p => p.Description).HasMaxLength(255);
		builder.Property(p => p.Payee).HasMaxLength(60);
		builder.Property(p => p.Payer).HasMaxLength(60);
		builder.Property(p => p.Reference).HasMaxLength(255);
		builder.Property(p => p.TransactionType).HasMaxLength(255);
		builder.Property(p => p.CategoriaId).HasColumnName("Fk_Categoria");
		builder.Property(p => p.RuleId).HasColumnName("Fk_Rule");
		builder.Property(p => p.AfterbanksTransactionId).HasMaxLength(100);
		builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
		builder.Property(p => p.Quantity).HasColumnType("money");
		/*builder.HasOne(d => d.Account)
			.WithMany(p => p.AccountsTransactions)
			.HasForeignKey(d => d.AccountId);*/

		/*builder.HasOne(d => d.Categoria)
			.WithMany(p => p.AccountsTransactions)
			.HasForeignKey(d => d.CategoriaId);*/

		/*builder.HasOne(d => d.Rule)
			.WithMany(p => p.AccountsTransactions)
			.HasForeignKey(d => d.RuleId);*/

	}
}
