using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class CredencialConfiguration : IEntityTypeConfiguration<Credencial>
	{
		public void Configure(EntityTypeBuilder<Credencial> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Credencial");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
			builder.Property(p => p.DatosConexion).HasMaxLength(255);
			builder.Property(p => p.Baja).IsRequired();
			builder.Property(p => p.DetenerRobot).IsRequired();
			builder.Property(p => p.RequiereSMS).IsRequired();

			/*builder.HasOne(d => d.EntidadFinanciera)
				.WithMany(p => p.Credenciales)
				.HasForeignKey(d => d.EntidadFinancieraId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.Credenciales)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}