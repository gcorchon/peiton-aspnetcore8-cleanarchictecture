using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
	public void Configure(EntityTypeBuilder<Loan> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Loan");
		builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");
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
		builder.Property(p => p.Baja).IsRequired();
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.UltimaActualizacion).HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Porcentaje).HasMaxLength(5);
		builder.Property(p => p.TipoPrestamoId).HasColumnName("Fk_TipoPrestamo");
		builder.Property(p => p.InitialBalance).HasColumnType("money");
		builder.Property(p => p.Debt).HasColumnType("money");
		/*builder.HasOne(d => d.Credencial)
			.WithMany(p => p.Loanes)
			.HasForeignKey(d => d.CredencialId);*/

	}
}
