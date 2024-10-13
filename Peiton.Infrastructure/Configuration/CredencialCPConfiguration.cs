using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CredencialCPConfiguration : IEntityTypeConfiguration<CredencialCP>
{
	public void Configure(EntityTypeBuilder<CredencialCP> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_CredencialCP");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.DatosConexion).HasMaxLength(255);
		builder.Property(p => p.Baja).IsRequired();
		builder.Property(p => p.DetenerRobot).IsRequired();
		builder.Property(p => p.RequiereSMS).IsRequired();

		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.CredencialesCP)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

	}
}
