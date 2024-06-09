using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
	{
		public void Configure(EntityTypeBuilder<Deposit> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Deposit");
			builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
			builder.Property(p => p.AccountNumber).HasMaxLength(10);
			builder.Property(p => p.WebAlias).HasMaxLength(255);
			builder.Property(p => p.Titularidad).HasMaxLength(10);
			builder.Property(p => p.Baja).IsRequired();
			builder.Property(p => p.CustomWebAlias).HasMaxLength(255);
			builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
			builder.Property(p => p.Saldo).HasColumnType("money");
			/*builder.HasOne(d => d.Credencial)
				.WithMany(p => p.Deposit)
				.HasForeignKey(d => d.CredencialId);*/

		}
	}
}