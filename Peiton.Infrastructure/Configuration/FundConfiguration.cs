using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class FundConfiguration : IEntityTypeConfiguration<Fund>
	{
		public void Configure(EntityTypeBuilder<Fund> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Fund");
			builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
			builder.Property(p => p.AccountNumber).HasMaxLength(10);
			builder.Property(p => p.FundName).HasMaxLength(255);
			builder.Property(p => p.Number).HasMaxLength(255);
			builder.Property(p => p.WebAlias).HasMaxLength(255);
			builder.Property(p => p.Titularidad).HasMaxLength(10);
			builder.Property(p => p.Baja).IsRequired();
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.CustomWebAlias).HasMaxLength(255);
			builder.Property(p => p.Origen).HasMaxLength(1).IsRequired().HasDefaultValueSql("('AB')");
			builder.Property(p => p.Saldo).HasColumnType("money");
			/*builder.HasOne(d => d.Credencial)
				.WithMany(p => p.Fundes)
				.HasForeignKey(d => d.CredencialId);*/

		}
	}
}