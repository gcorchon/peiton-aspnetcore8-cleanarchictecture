using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PuntoInformacionConfiguration : IEntityTypeConfiguration<PuntoInformacion>
	{
		public void Configure(EntityTypeBuilder<PuntoInformacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_PuntoInformacion");
			builder.Property(p => p.AbogadoId).HasColumnName("Fk_Abogado");
			builder.Property(p => p.TrabajadorSocialId).HasColumnName("Fk_TrabajadorSocial");
			builder.Property(p => p.Solicitante).HasMaxLength(255);
			builder.Property(p => p.DNI).HasMaxLength(20);
			builder.Property(p => p.Telefono).HasMaxLength(20);
			builder.Property(p => p.Email).HasMaxLength(255);
			builder.Property(p => p.PuntoInformacionTipoConsultaId).HasColumnName("Fk_PuntoInformacionTipoConsulta");

			/*builder.HasOne(d => d.Abogado)
				.WithMany(p => p.PuntosInformaciones)
				.HasForeignKey(d => d.AbogadoId);*/

			/*builder.HasOne(d => d.PuntoInformacionTipoConsulta)
				.WithMany(p => p.PuntosInformaciones)
				.HasForeignKey(d => d.PuntoInformacionTipoConsultaId);*/

			/*builder.HasOne(d => d.TrabajadorSocial)
				.WithMany(p => p.PuntosInformaciones)
				.HasForeignKey(d => d.TrabajadorSocialId);*/

		}
	}
}