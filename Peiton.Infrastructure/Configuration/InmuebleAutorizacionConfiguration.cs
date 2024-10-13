using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleAutorizacionConfiguration : IEntityTypeConfiguration<InmuebleAutorizacion>
{
	public void Configure(EntityTypeBuilder<InmuebleAutorizacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_InmuebleAutorizacion");
		builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
		builder.Property(p => p.InmuebleMotivoAutorizacionId).HasColumnName("Fk_InmuebleMotivoAutorizacion");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.Autorizado).IsRequired();
		builder.Property(p => p.Presentado).IsRequired();
		builder.Property(p => p.Fecha).HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Archivo).IsRequired();

		builder.HasOne(d => d.Inmueble)
			.WithMany(p => p.InmueblesAutorizaciones)
			.HasForeignKey(d => d.InmuebleId);

		/*builder.HasOne(d => d.InmuebleMotivoAutorizacion)
			.WithMany(p => p.InmueblesAutorizaciones)
			.HasForeignKey(d => d.InmuebleMotivoAutorizacionId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.InmueblesAutorizaciones)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
