using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
	public void Configure(EntityTypeBuilder<Account> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Account");
		builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.WebAlias).HasMaxLength(255);
		builder.Property(p => p.Titularidad).HasMaxLength(10);
		builder.Property(p => p.Baja).IsRequired();
		builder.Property(p => p.LibreDisposicion).IsRequired();
		builder.Property(p => p.CustomWebAlias).HasMaxLength(255);
		builder.Property(p => p.Iban).HasMaxLength(12);
		builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
		builder.Property(p => p.Saldo).HasColumnType("money");

		builder.HasOne(d => d.Credencial)
			.WithMany(p => p.Accounts)
			.HasForeignKey(d => d.CredencialId);

	}
}
