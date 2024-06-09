using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TransferenciaBeneficiarioConfiguration : IEntityTypeConfiguration<TransferenciaBeneficiario>
	{
		public void Configure(EntityTypeBuilder<TransferenciaBeneficiario> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TransferenciaBeneficiario");
			builder.Property(p => p.Nombre).HasMaxLength(255);

		}
	}
}