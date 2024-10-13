using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CredencialMasivaConfiguration : IEntityTypeConfiguration<CredencialMasiva>
{
	public void Configure(EntityTypeBuilder<CredencialMasiva> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CredencialMasiva");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.DatosConexion).HasMaxLength(255);

		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.CredencialesMasivas)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

	}
}
