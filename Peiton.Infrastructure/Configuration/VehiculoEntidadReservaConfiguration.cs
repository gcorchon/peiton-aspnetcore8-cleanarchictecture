using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class VehiculoEntidadReservaConfiguration : IEntityTypeConfiguration<VehiculoEntidadReserva>
	{
		public void Configure(EntityTypeBuilder<VehiculoEntidadReserva> builder)
		{
			builder.HasKey(t => new { t.VehiculoEntidadId, t.Fecha, t.Intervalo});

			builder.Property(p => p.VehiculoEntidadId).HasColumnName("Fk_VehiculoEntidad");
			builder.Property(p => p.Intervalo).HasMaxLength(2);
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.VehiculosEntidadesReservas)
				.HasForeignKey(d => d.UsuarioId);*/

			/*builder.HasOne(d => d.VehiculoEntidad)
				.WithMany(p => p.VehiculosEntidadesReservas)
				.HasForeignKey(d => d.VehiculoEntidadId);*/

		}
	}
}