using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AccountTransactionCPConfiguration : IEntityTypeConfiguration<AccountTransactionCP>
	{
		public void Configure(EntityTypeBuilder<AccountTransactionCP> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AccountTransactionCP");
			builder.Property(p => p.AccountCPId).HasColumnName("Fk_AccountCP");
			builder.Property(p => p.Description).HasMaxLength(255);
			builder.Property(p => p.Reference).HasMaxLength(255);
			builder.Property(p => p.Payer).HasMaxLength(255);
			builder.Property(p => p.Payee).HasMaxLength(255);
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Ocultar).IsRequired();
			builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
			builder.Property(p => p.AfterbanksTransactionId).HasMaxLength(100);
			builder.Property(p => p.Quantity).HasColumnType("money");
			/*builder.HasOne(d => d.AccountCP)
				.WithMany(p => p.AccountsTransactionsCP)
				.HasForeignKey(d => d.AccountCPId);*/

		}
	}
}