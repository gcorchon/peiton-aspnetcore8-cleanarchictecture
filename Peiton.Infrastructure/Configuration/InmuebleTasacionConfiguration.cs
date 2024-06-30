using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class InmuebleTasacionConfiguration : IEntityTypeConfiguration<InmuebleTasacion>
	{
		public void Configure(EntityTypeBuilder<InmuebleTasacion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_InmuebleTasacion");
			builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
			builder.Property(p => p.InmuebleTipoTasacionId).HasColumnName("Fk_InmuebleTipoTasacion");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.Autorizado).IsRequired();
			builder.Property(p => p.Presentado).IsRequired();
			builder.Property(p => p.Fecha).HasDefaultValueSql("(getdate())");
			builder.Property(p => p.InmuebleTasadorId).HasColumnName("Fk_InmuebleTasador");
			builder.Property(p => p.ValorTasacion).HasColumnType("money");
			builder.Property(p => p.PrecioVenta).HasColumnType("money");
			
			builder.HasOne(d => d.Inmueble)
				.WithMany(p => p.InmueblesTasaciones)
				.HasForeignKey(d => d.InmuebleId);

			/*builder.HasOne(d => d.InmuebleTipoTasacion)
				.WithMany(p => p.InmueblesTasaciones)
				.HasForeignKey(d => d.InmuebleTipoTasacionId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.InmueblesTasaciones)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}