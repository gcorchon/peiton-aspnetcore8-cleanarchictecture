using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CuentaCaixabankConfiguration : IEntityTypeConfiguration<CuentaCaixabank>
{
	public void Configure(EntityTypeBuilder<CuentaCaixabank> builder)
	{
		builder.HasKey(t => t.Iban);

		builder.Property(p => p.Iban).ValueGeneratedNever().HasMaxLength(50);
		builder.Property(p => p.CredencialId).HasColumnName("Fk_Credencial");

		/*builder.HasOne(d => d.Credencial)
			.WithMany(p => p.CuentasCaixabank)
			.HasForeignKey(d => d.CredencialId);*/

	}
}
