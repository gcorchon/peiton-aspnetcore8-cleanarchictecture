using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ArrendamientoConfiguration : IEntityTypeConfiguration<Arrendamiento>
{
	public void Configure(EntityTypeBuilder<Arrendamiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Arrendamiento");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoViaId).HasColumnName("Fk_TipoVia");
		builder.Property(p => p.Numero).HasMaxLength(10);
		builder.Property(p => p.Portal).HasMaxLength(10);
		builder.Property(p => p.Escalera).HasMaxLength(10);
		builder.Property(p => p.Piso).HasMaxLength(10);
		builder.Property(p => p.Puerta).HasMaxLength(10);
		builder.Property(p => p.CodigoPostal).HasMaxLength(10);
		builder.Property(p => p.Municipio).HasMaxLength(50);
		builder.Property(p => p.Barrio).HasMaxLength(50);
		builder.Property(p => p.DistritoId).HasColumnName("Fk_Distrito");
		builder.Property(p => p.ProvinciaId).HasColumnName("Fk_Provincia");
		builder.Property(p => p.RegistroCiudad).HasMaxLength(255);
		builder.Property(p => p.RegistroNumero).HasMaxLength(255);
		builder.Property(p => p.RegistroInscripcionReferencia).HasMaxLength(255);
		builder.Property(p => p.RegistroReferenciaCatastral).HasMaxLength(255);
		builder.Property(p => p.AgenteArrendamientoId).HasColumnName("Fk_AgenteArrendamiento");
		builder.Property(p => p.DireccionCompleta).HasComputedColumnSql("([dbo].[ObtenerDireccionCompletaArrendamiento]([Pk_Arrendamiento]))", false);
		builder.Property(p => p.RentaMensualArrendamiento).HasColumnType("money");
		/*builder.HasOne(d => d.AgenteArrendamiento)
			.WithMany(p => p.Arrendamientos)
			.HasForeignKey(d => d.AgenteArrendamientoId);*/

		/*builder.HasOne(d => d.Distrito)
			.WithMany(p => p.Arrendamientos)
			.HasForeignKey(d => d.DistritoId);*/

		/*builder.HasOne(d => d.Provincia)
			.WithMany(p => p.Arrendamientos)
			.HasForeignKey(d => d.ProvinciaId);*/

		/*builder.HasOne(d => d.TipoVia)
			.WithMany(p => p.Arrendamientos)
			.HasForeignKey(d => d.TipoViaId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Arrendamientos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
