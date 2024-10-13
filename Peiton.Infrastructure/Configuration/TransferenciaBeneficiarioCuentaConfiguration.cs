using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TransferenciaBeneficiarioCuentaConfiguration : IEntityTypeConfiguration<TransferenciaBeneficiarioCuenta>
{
	public void Configure(EntityTypeBuilder<TransferenciaBeneficiarioCuenta> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TransferenciaBeneficiarioCuenta");
		builder.Property(p => p.TransferenciaBeneficiarioId).HasColumnName("Fk_TransferenciaBeneficiario");
		builder.Property(p => p.Cuenta).HasMaxLength(50);

		/*builder.HasOne(d => d.TransferenciaBeneficiario)
			.WithMany(p => p.TransferenciasBeneficiariosCuentas)
			.HasForeignKey(d => d.TransferenciaBeneficiarioId);*/

	}
}
