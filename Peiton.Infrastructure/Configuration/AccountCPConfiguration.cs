using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AccountCPConfiguration : IEntityTypeConfiguration<AccountCP>
	{
		public void Configure(EntityTypeBuilder<AccountCP> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AccountCP");
			builder.Property(p => p.CredencialCPId).HasColumnName("Fk_CredencialCP");
			builder.Property(p => p.WebAlias).HasMaxLength(255);
			builder.Property(p => p.Baja).IsRequired();
			builder.Property(p => p.Iban).HasMaxLength(12);
			builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
			builder.Property(p => p.Saldo).HasColumnType("money");
			/*builder.HasOne(d => d.CredencialCP)
				.WithMany(p => p.AccountsCP)
				.HasForeignKey(d => d.CredencialCPId);*/

		}
	}
}