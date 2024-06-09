using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EntidadGestoraConfiguration : IEntityTypeConfiguration<EntidadGestora>
	{
		public void Configure(EntityTypeBuilder<EntidadGestora> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_EntidadGestora");
			builder.Property(p => p.Nombre).HasMaxLength(255);
			builder.Property(p => p.ComunidadAutonomaId).HasColumnName("Fk_ComunidadAutonoma");
			builder.Property(p => p.ProvinciaId).HasColumnName("Fk_Provincia");
			builder.Property(p => p.Municipio).HasMaxLength(100);
			builder.Property(p => p.CodigoPostal).HasMaxLength(2);
			builder.Property(p => p.Direccion).HasMaxLength(150);
			builder.Property(p => p.Telefono).HasMaxLength(4);
			builder.Property(p => p.Fax).HasMaxLength(4);
			builder.Property(p => p.Email).HasMaxLength(100);
			builder.Property(p => p.Web).HasMaxLength(200);
			builder.Property(p => p.NumeroInscripcionRegistroFundaciones).HasMaxLength(50);
			builder.Property(p => p.NumeroInscripcionRegistroUnificadoServiciosSociales).HasMaxLength(50);
			builder.Property(p => p.CIF).HasMaxLength(10);
			builder.Property(p => p.TitularidadServicioEntidadGestoraId).HasColumnName("Fk_TitularidadServicioEntidadGestora");
			builder.Property(p => p.Representante).HasMaxLength(250);
			builder.Property(p => p.AmbitoCoberturaServicioId).HasColumnName("Fk_AmbitoCoberturaServicio");

			/*builder.HasOne(d => d.AmbitoCoberturaServicio)
				.WithMany(p => p.EntidadesGestoras)
				.HasForeignKey(d => d.AmbitoCoberturaServicioId);*/

			/*builder.HasOne(d => d.ComunidadAutonoma)
				.WithMany(p => p.EntidadesGestoras)
				.HasForeignKey(d => d.ComunidadAutonomaId);*/

			/*builder.HasOne(d => d.Provincia)
				.WithMany(p => p.EntidadesGestoras)
				.HasForeignKey(d => d.ProvinciaId);*/

			/*builder.HasOne(d => d.TitularidadServicioEntidadGestora)
				.WithMany(p => p.EntidadesGestoras)
				.HasForeignKey(d => d.TitularidadServicioEntidadGestoraId);*/

		}
	}
}